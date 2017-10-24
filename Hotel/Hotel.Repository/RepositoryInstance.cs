
using Hotel.Entities;
using Microsoft.Extensions.DependencyInjection;
using HTActive.Core.Repository;
using System;

namespace Hotel.Repository
{
    public class InstanceUnitOfWork : BaseUnitOfWork<InstanceEntities>
    {
        public InstanceUnitOfWork(InstanceEntities entity)
            : base(entity)
        {
        }
    }
    public class InstanceRepository
    {
	    public IServiceProvider ServiceProvider{get;private set;}
		public IBaseUnitOfWork<InstanceEntities> InstanceUnitOfWork{get;private set;}
        public InstanceRepository(IBaseUnitOfWork<InstanceEntities> unitOfWork, IServiceProvider _serviceProvider)
        {
			this.InstanceUnitOfWork = unitOfWork;
			this.ServiceProvider = _serviceProvider;
		}
        public void Commit()
        {
            this.InstanceUnitOfWork.Commit();
        }
        #region Repositories
        private IClaimRepository _ClaimRepository;
        public IClaimRepository ClaimRepository 
		{ 
			get
			{
				return _ClaimRepository ?? 
				(_ClaimRepository = ServiceProvider.GetService<IClaimRepository>());
			}
		}
		private IImageRepository _ImageRepository;
        public IImageRepository ImageRepository 
		{ 
			get
			{
				return _ImageRepository ?? 
				(_ImageRepository = ServiceProvider.GetService<IImageRepository>());
			}
		}
		private IRoleRepository _RoleRepository;
        public IRoleRepository RoleRepository 
		{ 
			get
			{
				return _RoleRepository ?? 
				(_RoleRepository = ServiceProvider.GetService<IRoleRepository>());
			}
		}
		private IRoleClaimRepository _RoleClaimRepository;
        public IRoleClaimRepository RoleClaimRepository 
		{ 
			get
			{
				return _RoleClaimRepository ?? 
				(_RoleClaimRepository = ServiceProvider.GetService<IRoleClaimRepository>());
			}
		}
		private IUserRepository _UserRepository;
        public IUserRepository UserRepository 
		{ 
			get
			{
				return _UserRepository ?? 
				(_UserRepository = ServiceProvider.GetService<IUserRepository>());
			}
		}
		private IUserLoginTokenRepository _UserLoginTokenRepository;
        public IUserLoginTokenRepository UserLoginTokenRepository 
		{ 
			get
			{
				return _UserLoginTokenRepository ?? 
				(_UserLoginTokenRepository = ServiceProvider.GetService<IUserLoginTokenRepository>());
			}
		}
		private IUserProfileRepository _UserProfileRepository;
        public IUserProfileRepository UserProfileRepository 
		{ 
			get
			{
				return _UserProfileRepository ?? 
				(_UserProfileRepository = ServiceProvider.GetService<IUserProfileRepository>());
			}
		}
		private IUserRoleRepository _UserRoleRepository;
        public IUserRoleRepository UserRoleRepository 
		{ 
			get
			{
				return _UserRoleRepository ?? 
				(_UserRoleRepository = ServiceProvider.GetService<IUserRoleRepository>());
			}
		}
		private ICompanyRepository _CompanyRepository;
        public ICompanyRepository CompanyRepository 
		{ 
			get
			{
				return _CompanyRepository ?? 
				(_CompanyRepository = ServiceProvider.GetService<ICompanyRepository>());
			}
		}
		private ICompanyInfoRepository _CompanyInfoRepository;
        public ICompanyInfoRepository CompanyInfoRepository 
		{ 
			get
			{
				return _CompanyInfoRepository ?? 
				(_CompanyInfoRepository = ServiceProvider.GetService<ICompanyInfoRepository>());
			}
		}
		private IArticleRepository _ArticleRepository;
        public IArticleRepository ArticleRepository 
		{ 
			get
			{
				return _ArticleRepository ?? 
				(_ArticleRepository = ServiceProvider.GetService<IArticleRepository>());
			}
		}
		private IRoomRepository _RoomRepository;
        public IRoomRepository RoomRepository 
		{ 
			get
			{
				return _RoomRepository ?? 
				(_RoomRepository = ServiceProvider.GetService<IRoomRepository>());
			}
		}
		private IPhotoRepository _PhotoRepository;
        public IPhotoRepository PhotoRepository 
		{ 
			get
			{
				return _PhotoRepository ?? 
				(_PhotoRepository = ServiceProvider.GetService<IPhotoRepository>());
			}
		}
		private IServiceRepository _ServiceRepository;
        public IServiceRepository ServiceRepository 
		{ 
			get
			{
				return _ServiceRepository ?? 
				(_ServiceRepository = ServiceProvider.GetService<IServiceRepository>());
			}
		}
		private ITopSlideRepository _TopSlideRepository;
        public ITopSlideRepository TopSlideRepository 
		{ 
			get
			{
				return _TopSlideRepository ?? 
				(_TopSlideRepository = ServiceProvider.GetService<ITopSlideRepository>());
			}
		}
		#endregion
    }
	
    public static class RegisterServiceHelper
    {
        public static void RegisterRepository(IServiceCollection services)
        {
			services.AddScoped<IClaimRepository, ClaimRepository>();
			services.AddScoped<IImageRepository, ImageRepository>();
			services.AddScoped<IRoleRepository, RoleRepository>();
			services.AddScoped<IRoleClaimRepository, RoleClaimRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IUserLoginTokenRepository, UserLoginTokenRepository>();
			services.AddScoped<IUserProfileRepository, UserProfileRepository>();
			services.AddScoped<IUserRoleRepository, UserRoleRepository>();
			services.AddScoped<ICompanyRepository, CompanyRepository>();
			services.AddScoped<ICompanyInfoRepository, CompanyInfoRepository>();
			services.AddScoped<IArticleRepository, ArticleRepository>();
			services.AddScoped<IRoomRepository, RoomRepository>();
			services.AddScoped<IPhotoRepository, PhotoRepository>();
			services.AddScoped<IServiceRepository, ServiceRepository>();
			services.AddScoped<ITopSlideRepository, TopSlideRepository>();
		}
    }
}