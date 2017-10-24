
using Hotel.Entities;
using HTActive.Core.Repository;
namespace Hotel.Repository
{
    public partial class ClaimRepository : BaseRepository<Claim, InstanceEntities>, IClaimRepository
    {
        public ClaimRepository(IBaseUnitOfWork<InstanceEntities> unitOfWork)
            : base(unitOfWork)
        {

        }
		protected override int GetKeyId(Claim model)
        {
            return model.Id;
        }
	}

    public partial class ImageRepository : BaseRepository<Image, InstanceEntities>, IImageRepository
    {
        public ImageRepository(IBaseUnitOfWork<InstanceEntities> unitOfWork)
            : base(unitOfWork)
        {

        }
		protected override int GetKeyId(Image model)
        {
            return model.Id;
        }
	}

    public partial class RoleRepository : BaseRepository<Role, InstanceEntities>, IRoleRepository
    {
        public RoleRepository(IBaseUnitOfWork<InstanceEntities> unitOfWork)
            : base(unitOfWork)
        {

        }
		protected override int GetKeyId(Role model)
        {
            return model.Id;
        }
	}

    public partial class RoleClaimRepository : BaseRepository<RoleClaim, InstanceEntities>, IRoleClaimRepository
    {
        public RoleClaimRepository(IBaseUnitOfWork<InstanceEntities> unitOfWork)
            : base(unitOfWork)
        {

        }
		protected override int GetKeyId(RoleClaim model)
        {
            return model.Id;
        }
	}

    public partial class UserRepository : BaseRepository<User, InstanceEntities>, IUserRepository
    {
        public UserRepository(IBaseUnitOfWork<InstanceEntities> unitOfWork)
            : base(unitOfWork)
        {

        }
		protected override int GetKeyId(User model)
        {
            return model.Id;
        }
	}

    public partial class UserLoginTokenRepository : BaseRepository<UserLoginToken, InstanceEntities>, IUserLoginTokenRepository
    {
        public UserLoginTokenRepository(IBaseUnitOfWork<InstanceEntities> unitOfWork)
            : base(unitOfWork)
        {

        }
		protected override int GetKeyId(UserLoginToken model)
        {
            return model.Id;
        }
	}

    public partial class UserProfileRepository : BaseRepository<UserProfile, InstanceEntities>, IUserProfileRepository
    {
        public UserProfileRepository(IBaseUnitOfWork<InstanceEntities> unitOfWork)
            : base(unitOfWork)
        {

        }
		protected override int GetKeyId(UserProfile model)
        {
            return model.Id;
        }
	}

    public partial class UserRoleRepository : BaseRepository<UserRole, InstanceEntities>, IUserRoleRepository
    {
        public UserRoleRepository(IBaseUnitOfWork<InstanceEntities> unitOfWork)
            : base(unitOfWork)
        {

        }
		protected override int GetKeyId(UserRole model)
        {
            return model.Id;
        }
	}

    public partial class CompanyRepository : BaseRepository<Company, InstanceEntities>, ICompanyRepository
    {
        public CompanyRepository(IBaseUnitOfWork<InstanceEntities> unitOfWork)
            : base(unitOfWork)
        {

        }
		protected override int GetKeyId(Company model)
        {
            return model.Id;
        }
	}

    public partial class CompanyInfoRepository : BaseRepository<CompanyInfo, InstanceEntities>, ICompanyInfoRepository
    {
        public CompanyInfoRepository(IBaseUnitOfWork<InstanceEntities> unitOfWork)
            : base(unitOfWork)
        {

        }
		protected override int GetKeyId(CompanyInfo model)
        {
            return model.Id;
        }
	}

    public partial class ArticleRepository : BaseRepository<Article, InstanceEntities>, IArticleRepository
    {
        public ArticleRepository(IBaseUnitOfWork<InstanceEntities> unitOfWork)
            : base(unitOfWork)
        {

        }
		protected override int GetKeyId(Article model)
        {
            return model.Id;
        }
	}

    public partial class RoomRepository : BaseRepository<Room, InstanceEntities>, IRoomRepository
    {
        public RoomRepository(IBaseUnitOfWork<InstanceEntities> unitOfWork)
            : base(unitOfWork)
        {

        }
		protected override int GetKeyId(Room model)
        {
            return model.Id;
        }
	}

    public partial class PhotoRepository : BaseRepository<Photo, InstanceEntities>, IPhotoRepository
    {
        public PhotoRepository(IBaseUnitOfWork<InstanceEntities> unitOfWork)
            : base(unitOfWork)
        {

        }
		protected override int GetKeyId(Photo model)
        {
            return model.Id;
        }
	}

    public partial class ServiceRepository : BaseRepository<Service, InstanceEntities>, IServiceRepository
    {
        public ServiceRepository(IBaseUnitOfWork<InstanceEntities> unitOfWork)
            : base(unitOfWork)
        {

        }
		protected override int GetKeyId(Service model)
        {
            return model.Id;
        }
	}

    public partial class TopSlideRepository : BaseRepository<TopSlide, InstanceEntities>, ITopSlideRepository
    {
        public TopSlideRepository(IBaseUnitOfWork<InstanceEntities> unitOfWork)
            : base(unitOfWork)
        {

        }
		protected override int GetKeyId(TopSlide model)
        {
            return model.Id;
        }
	}
}