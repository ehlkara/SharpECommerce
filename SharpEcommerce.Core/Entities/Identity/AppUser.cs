using Microsoft.AspNetCore.Identity;

namespace SharpEcommerce.Core.Entities.Identity
{
    public class AppUser : IdentityUser
	{
		public string DisplayName { get; set; }
		public Address Address { get; set; }
	}
}

