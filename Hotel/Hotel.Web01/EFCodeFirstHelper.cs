using Hotel.Entities;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Web01
{
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<InstanceEntities>
    {
        public InstanceEntities CreateDbContext(string[] args)
        {
            return Program.BuildWebHost(args).Services.CreateScope().ServiceProvider.GetRequiredService<InstanceEntities>();
        }
    }
}
