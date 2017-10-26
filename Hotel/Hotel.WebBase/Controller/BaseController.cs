using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hotel.Repository;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Hotel.WebBase.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Hotel.Common;
using Hotel.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using HTActive.Web.Helpers;
using HTActive.Common;

namespace Hotel.WebBase.Controllers
{
    public class BaseController : Controller
    {
        const int TakeInHome = 20;
        protected InstanceRepository Repository { get; private set; }

        public BaseController(InstanceRepository repository)
        {
            this.Repository = repository;
            Configuration = repository.ServiceProvider.GetService<IOptions<ConfigurationHelper>>()?.Value;
        }

        protected ConfigurationHelper Configuration { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var ccValidateResult = ValidateCurrentCompany(context);
            if (!string.IsNullOrEmpty(ccValidateResult))
            {
                throw new Exception(ccValidateResult);
            }
            ViewBag.CurrentUser = this.CurrentUser;
            ViewBag.CurrentCompanyInfo = this.GetCompanyInfo();
            base.OnActionExecuting(context);
        }

        private string ValidateCurrentCompany(ActionExecutingContext context)
        {
            var domain = context.HttpContext.Request.Host.Host;
            if (string.IsNullOrEmpty(domain))
            {
                return "VCC_cc_Empty";
            }
            if (domain == "localhost")
            {
                domain = "00.khachsantest.htactive.com";
            }
            
            domain = domain.Substring(3);
            var entity = this.Repository.CompanyRepository.GetAll().FirstOrDefault(x => x.CompanyCode == domain);
            if (entity == null)
            {
                return "VCC_cc_NotFound";
            }
            if (!entity.IsActive.HasValue || !entity.IsActive.Value)
            {
                return "VCC_cc_Inactive";
            }
            this.CurrentCompany = Mappers.Mapper.ToModel(entity);
            ViewBag.CurrentCompany = this.CurrentCompany;
            ViewBag.BaseHref = $"/";
            return string.Empty;
        }

        private UserModel currentUser;

        protected UserModel CurrentUser
        {
            get
            {
                if (currentUser == null)
                {
                    string jwt = this.HttpContext.Request.Cookies["auth"];

                    if (string.IsNullOrEmpty(jwt) || jwt == "null") return null;

                    var payloadString = JwtHelper.Decode(jwt);

                    if (string.IsNullOrEmpty(payloadString)) return null;

                    var payLoad = JsonConvert.DeserializeObject<Dictionary<string, string>>(payloadString);
                    var token = payLoad["token"];
                    if (string.IsNullOrEmpty(token)) return null;

                    var loginSession = Repository.UserLoginTokenRepository.GetAll()
                        .Include("User.UserProfiles.Image")
                        .Include("User.UserRoles.Role")
                        .FirstOrDefault(x => x.Token == token);
                    if (loginSession == null || loginSession.User == null) return null;

                    //Check if user was banned
                    if (loginSession?.User?.UserStatusId == UserStatusEnums.Deactive) return null;

                    if (loginSession.ExpiredDated < DateTimeHelper.GetDateTimeNow())
                    {
                        return null;
                    }

                    currentUser = Mappers.Mapper.ToModel(loginSession.User);
                    if (currentUser != null)
                    {
                        currentUser.UserProfiles = loginSession.User.UserProfiles.Select(x =>
                        {
                            var profile = Mappers.Mapper.ToModel(x);
                            if (profile != null)
                            {
                                profile.Image = Mappers.Mapper.ToModel(x.Image);
                            }
                            return profile;
                        }).ToList();
                        currentUser.UserRoles = loginSession.User.UserRoles.Select(x =>
                        {
                            var role = Mappers.Mapper.ToModel(x);
                            if (role != null)
                            {
                                role.Role = Mappers.Mapper.ToModel(x.Role);
                            }
                            return role;
                        }).ToList();
                    }
                }
                return currentUser;
            }
        }

        protected CompanyModel CurrentCompany
        {
            get; private set;
        }

        protected HomePageViewModel GetHomePage()
        {
            var viewmodel = new HomePageViewModel
            {
                TopSlides = GetTopSlides(),
                Rooms = GetRoomsListPage(TakeInHome, null)?.Rooms,
                Services = GetServicesListPage(TakeInHome, null).Services,
                Articles = GetArticlesListPage(TakeInHome, null)?.Articles,
                Photos = this.GetPhotosListPage(TakeInHome, null).Photos
            };
            ViewBag.TabName = "home";
            return viewmodel;
        }

        protected RoomsListPageViewModel GetRoomsListPage(int pageSize, int? currentPage = 0)
        {
            if (CurrentCompany == null) return null;
            if (pageSize <= 0)
            {
                throw new Exception("PageSize should be greater than zero");
            }

            var query = this.Repository.RoomRepository.GetAll()
                .Include(x => x.CoverImage)
                .Include("RoomImages.Image")
                .Where(x => x.CompanyId == this.CurrentCompany.Id && x.IsHidden != true);

            var totalCount = currentPage == null ? 0 : query.Count();
            var entities = query
                .OrderBy(x => x.Priority)
                .Skip((currentPage ?? 0) * pageSize).Take(pageSize).ToList();

            var viewmodel = new RoomsListPageViewModel()
            {
                CurrentPage = currentPage ?? 0,
                PageSize = pageSize,
                TotalPage = (int)Math.Ceiling(1.0 * totalCount / pageSize),
                Rooms = entities.Select(x => Mappers.Mapper.ToModel(x, (m, e) =>
                {
                    m.CoverImage = Mappers.Mapper.ToModel(e.CoverImage);
                    m.RoomImages = e.RoomImages.Select(r => Mappers.Mapper.ToModel(r, (mm, ee) =>
                    {
                        mm.Image = Mappers.Mapper.ToModel(ee.Image);
                    })).ToList();
                })).ToList()
            };
            ViewBag.TabName = "room";
            return viewmodel;
        }

        protected RoomDetailPageViewModel GetRoomDetailPage(string request)
        {
            if (this.CurrentCompany == null) return null;
            request = (request ?? string.Empty).ToLower();
            var query = this.Repository.RoomRepository.GetAll()
                .Include(x => x.CoverImage)
                .Include("RoomImages.Image")
                .Where(x => x.CompanyId == this.CurrentCompany.Id);
            var entity = query.FirstOrDefault(x => x.Slug == request);
            if (entity == null)
            {
                if (int.TryParse(request, out int id))
                {
                    entity = query.FirstOrDefault(x => x.Id == id);
                }
            }
            if (entity == null || entity.IsHidden == true)
            {
                return null;
            }
            var relatedRooms = query.Where(x => x.IsHidden != true && x.Id != entity.Id)
                .OrderBy(x => x.Priority - entity.Priority > 0 ? (x.Priority - entity.Priority) : (entity.Priority - x.Priority)).Take(TakeInHome).ToList();
            Func<Room, RoomModel> mapper = (en) =>
            {
                return Mappers.Mapper.ToModel(en, (m, e) =>
                {
                    m.CoverImage = Mappers.Mapper.ToModel(e.CoverImage);
                    m.RoomImages = e.RoomImages.Select(r => Mappers.Mapper.ToModel(r, (mm, ee) =>
                    {
                        mm.Image = Mappers.Mapper.ToModel(ee.Image);
                    })).ToList();
                });
            };
            var viewmodel = new RoomDetailPageViewModel()
            {
                Room = mapper(entity),
                RelatedRooms = relatedRooms.Select(mapper).ToList()
            };
            ViewBag.TabName = "room";
            return viewmodel;
        }

        protected ArticlesListPageViewModel GetArticlesListPage(int pageSize, int? currentPage = 0)
        {
            if (CurrentCompany == null) return null;
            if (pageSize <= 0)
            {
                throw new Exception("PageSize should be greater than zero");
            }

            var query = this.Repository.ArticleRepository.GetAll().
                Include(x => x.CoverImage)
                .Where(x => x.CompanyId == this.CurrentCompany.Id && x.IsHidden != true);
            var totalCount = currentPage == null ? 0 : query.Count();
            var entities = query
                .OrderByDescending(x => x.CreatedDate)
                .Skip((currentPage ?? 0) * pageSize)
                .Take(pageSize)
                .ToList();
            var viewmodel = new ArticlesListPageViewModel()
            {
                CurrentPage = currentPage ?? 0,
                PageSize = pageSize,
                TotalPage = (int)Math.Ceiling(1.0 * totalCount / pageSize),
                Articles = entities.Select(x => Mappers.Mapper.ToModel(x, (m, e) =>
                {
                    m.CoverImage = Mappers.Mapper.ToModel(e.CoverImage);
                })).ToList(),

            };
            ViewBag.TabName = "article";
            return viewmodel;
        }

        protected ArticleDetailPageViewModel GetArticleDetailPage(string request)
        {
            if (this.CurrentCompany == null) return null;
            request = (request ?? string.Empty).ToLower();
            var query = this.Repository.ArticleRepository.GetAll()
                .Include(x => x.CoverImage)
                .Where(x => x.CompanyId == this.CurrentCompany.Id);
            var entity = query.FirstOrDefault(x => x.Slug == request);
            if (entity == null)
            {
                if (int.TryParse(request, out int id))
                {
                    entity = query.FirstOrDefault(x => x.Id == id);
                }
            }
            if (entity == null || entity.IsHidden == true)
            {
                return null;
            }
            var relatedArticles = query.Where(x => x.IsHidden != true && x.Id != entity.Id && x.CreatedDate <= entity.CreatedDate)
                .OrderByDescending(x => x.CreatedDate).Take(TakeInHome).ToList();
            Func<Article, ArticleModel> mapper = (en) =>
            {
                return Mappers.Mapper.ToModel(en, (m, e) =>
                {
                    m.CoverImage = Mappers.Mapper.ToModel(e.CoverImage);
                });
            };
            var viewmodel = new ArticleDetailPageViewModel()
            {
                Article = mapper(entity),
                RelatedArticles = relatedArticles.Select(mapper).ToList()
            };
            ViewBag.TabName = "article";
            return viewmodel;
        }

        protected ServicesListPageViewModel GetServicesListPage(int pageSize, int? currentPage = 0)
        {
            if (CurrentCompany == null) return null;
            if (pageSize <= 0)
            {
                throw new Exception("PageSize should be greater than zero");
            }

            var query = this.Repository.ServiceRepository.GetAll().
                Include(x => x.CoverImage)
                .Where(x => x.CompanyId == this.CurrentCompany.Id && x.IsHidden != true);
            var totalCount = currentPage == null ? 0 : query.Count();
            var entities = query
                .OrderBy(x => x.Priority)
                .Skip((currentPage ?? 0) * pageSize)
                .Take(pageSize)
                .ToList();
            var viewmodel = new ServicesListPageViewModel()
            {
                CurrentPage = currentPage ?? 0,
                PageSize = pageSize,
                TotalPage = (int)Math.Ceiling(1.0 * totalCount / pageSize),
                Services = entities.Select(x => Mappers.Mapper.ToModel(x, (m, e) =>
                {
                    m.CoverImage = Mappers.Mapper.ToModel(e.CoverImage);
                })).ToList(),

            };
            ViewBag.TabName = "service";
            return viewmodel;
        }

        protected ServiceDetailPageViewModel GetServiceDetailPage(string request)
        {
            if (this.CurrentCompany == null) return null;
            request = (request ?? string.Empty).ToLower();
            var query = this.Repository.ServiceRepository.GetAll()
                .Include(x => x.CoverImage)
                .Where(x => x.CompanyId == this.CurrentCompany.Id);
            var entity = query.FirstOrDefault(x => x.Slug == request);
            if (entity == null)
            {
                if (int.TryParse(request, out int id))
                {
                    entity = query.FirstOrDefault(x => x.Id == id);
                }
            }
            if (entity == null || entity.IsHidden == true)
            {
                return null;
            }
            var relatedServices = query.Where(x => x.IsHidden != true && x.Id != entity.Id)
                .OrderBy(x => x.Priority - entity.Priority > 0 ? (x.Priority - entity.Priority) : (entity.Priority - x.Priority))
                .Take(TakeInHome).ToList();
            Func<Service, ServiceModel> mapper = (en) =>
            {
                return Mappers.Mapper.ToModel(en, (m, e) =>
                {
                    m.CoverImage = Mappers.Mapper.ToModel(e.CoverImage);
                });
            };
            var viewmodel = new ServiceDetailPageViewModel()
            {
                Service = mapper(entity),
                RelatedServices = relatedServices.Select(mapper).ToList()
            };
            ViewBag.TabName = "service";
            return viewmodel;
        }

        protected PhotosListPageViewModel GetPhotosListPage(int pageSize, int? currentPage = 0)
        {
            if (CurrentCompany == null) return null;
            if (pageSize <= 0)
            {
                throw new Exception("PageSize should be greater than zero");
            }

            var query = this.Repository.PhotoRepository.GetAll().
                Include(x => x.Image)
                .Where(x => x.CompanyId == this.CurrentCompany.Id && x.IsHidden != true);
            var totalCount = currentPage == null ? 0 : query.Count();
            var entities = query
                .OrderBy(x => x.Priority).ThenByDescending(x => x.CreatedDate)
                .Skip((currentPage ?? 0) * pageSize)
                .Take(pageSize)
                .ToList();
            var viewmodel = new PhotosListPageViewModel()
            {
                CurrentPage = currentPage ?? 0,
                PageSize = pageSize,
                TotalPage = (int)Math.Ceiling(1.0 * totalCount / pageSize),
                Photos = entities.Select(x => Mappers.Mapper.ToModel(x, (m, e) =>
                {
                    m.Image = Mappers.Mapper.ToModel(e.Image);
                })).ToList(),
            };
            ViewBag.TabName = "gallery";
            return viewmodel;
        }

        #region Private method
        private CompanyInfoModel GetCompanyInfo()
        {
            if (CurrentCompany == null) return null;
            var entity = Repository.CompanyInfoRepository.GetAll()
                .Include(x => x.Logo)
                .FirstOrDefault(x => x.CompanyId == this.CurrentCompany.Id);
            var model = Mappers.Mapper.ToModel(entity);
            if (model != null)
            {
                model.Logo = Mappers.Mapper.ToModel(entity.Logo);
            }
            return model;
        }

        private List<TopSlideModel> GetTopSlides()
        {
            if (CurrentCompany == null) return null;
            var entities = this.Repository.TopSlideRepository.GetAll()
                .Include(x => x.Image)
                .Where(x => x.CompanyId == this.CurrentCompany.Id && x.IsHidden != true)
                .OrderBy(x => x.Priority).Take(TakeInHome).ToList();
            var models = entities.Select(x => Mappers.Mapper.ToModel(x, (m, e) =>
            {
                m.Image = Mappers.Mapper.ToModel(e.Image);
            })).ToList();
            return models;
        }

        #endregion

    }
}
