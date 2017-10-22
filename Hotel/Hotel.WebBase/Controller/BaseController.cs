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
    }
}
