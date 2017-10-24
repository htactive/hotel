
using Hotel.Entities;
using HTActive.Core.Repository;
namespace Hotel.Repository
{
    public partial interface IClaimRepository : IBaseRepository<Claim>
    {
    }

    public partial interface IImageRepository : IBaseRepository<Image>
    {
    }

    public partial interface IRoleRepository : IBaseRepository<Role>
    {
    }

    public partial interface IRoleClaimRepository : IBaseRepository<RoleClaim>
    {
    }

    public partial interface IUserRepository : IBaseRepository<User>
    {
    }

    public partial interface IUserLoginTokenRepository : IBaseRepository<UserLoginToken>
    {
    }

    public partial interface IUserProfileRepository : IBaseRepository<UserProfile>
    {
    }

    public partial interface IUserRoleRepository : IBaseRepository<UserRole>
    {
    }

    public partial interface ICompanyRepository : IBaseRepository<Company>
    {
    }

    public partial interface ICompanyInfoRepository : IBaseRepository<CompanyInfo>
    {
    }

    public partial interface IArticleRepository : IBaseRepository<Article>
    {
    }

    public partial interface IRoomRepository : IBaseRepository<Room>
    {
    }

    public partial interface IPhotoRepository : IBaseRepository<Photo>
    {
    }

    public partial interface IServiceRepository : IBaseRepository<Service>
    {
    }

    public partial interface ITopSlideRepository : IBaseRepository<TopSlide>
    {
    }
}