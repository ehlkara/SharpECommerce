using Microsoft.EntityFrameworkCore;
using SharpEcommerce.Infrastructure.Data.Identity;

namespace SharpEcommerce.API.Extensions
{
    public static class IdentityServiceExtensions
	{
		public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
		{
			services.AddDbContext<AppIdentityDbContext>(opt =>
			{
				opt.UseNpgsql(config.GetConnectionString("IdentityConnection"));
			});
			
			return services;
		}
	}
}

