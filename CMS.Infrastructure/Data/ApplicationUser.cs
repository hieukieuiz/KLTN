using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CMS.Infrastructure.Data
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
