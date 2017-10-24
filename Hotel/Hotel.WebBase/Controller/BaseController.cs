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
            base.OnActionExecuting(context);
        }

        private string ValidateCurrentCompany(ActionExecutingContext context)
        {
            if (!context.RouteData.Values.ContainsKey("cc"))
            {
                return "VCC_cc_Empty";
            }
            var code = context.RouteData.Values["cc"]?.ToString().ToLower();
            var entity = this.Repository.CompanyRepository.GetAll().FirstOrDefault(x => x.CompanyCode == code);
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
            ViewBag.BaseHref = $"/{ this.CurrentCompany.CompanyCode}/";
            ViewBag.CurrentCompanyInfo = this.GetCompanyInfo();
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
                CompanyInfo = GetCompanyInfo(),
                TopSlides = GetTopSlides(),
                Rooms = GetRoomsInHome()
            };

            return viewmodel;
        }
        protected CompanyInfoModel GetCompanyInfo()
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

        protected List<TopSlideModel> GetTopSlides()
        {
            if (CurrentCompany == null) return null;
            var entities = this.Repository.TopSlideRepository.GetAll()
                .Include(x => x.Image)
                .Where(x => x.CompanyId == this.CurrentCompany.Id).Take(10).ToList();
            var models = entities.Select(x => Mappers.Mapper.ToModel(x, (m, e) =>
            {
                m.Image = Mappers.Mapper.ToModel(e.Image);
            })).ToList();
            return models;
        }

        protected List<RoomModel> GetRoomsInHome()
        {
            if (CurrentCompany == null) return null;
            var entities = this.Repository.RoomRepository.GetAll()
                .Include(x => x.CoverImage)
                .Include("RoomImages.Image")
                .Where(x => x.CompanyId == this.CurrentCompany.Id)
                .Take(10)
                .ToList();
            var models = entities.Select(x => Mappers.Mapper.ToModel(x, (m, e) =>
            {
                m.CoverImage = Mappers.Mapper.ToModel(e.CoverImage);
                m.RoomImages = e.RoomImages.Select(r => Mappers.Mapper.ToModel(r, (mm, ee) =>
                {
                    mm.Image = Mappers.Mapper.ToModel(ee.Image);
                })).ToList();
            })).ToList();
            return models;
        }
    }
}
