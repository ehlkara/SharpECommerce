using SharpEcommerce.Core.Entities.Identity;

namespace SharpEcommerce.Core.Interfaces
{
    public interface ITokenService
	{
		string CreateToken(AppUser user);
	}
}

