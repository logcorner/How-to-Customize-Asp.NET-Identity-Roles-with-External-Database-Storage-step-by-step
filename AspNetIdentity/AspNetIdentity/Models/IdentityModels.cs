using IdentityLibrary.DataModel;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AspNetIdentity.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityLibrary.IdentityUser //*/Microsoft.AspNet.Identity.EntityFramework.IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    #region 1

    public class ApplicationRole : IdentityLibrary.IdentityRole
    {
        public ApplicationRole() : base()
        {
        }

        public ApplicationRole(string name) : base(name)
        {
        }

        public string Description { get; set; }
    }

    #endregion 1

    public class ApplicationDbContext : DatabaseContext//IdentityDbContext<ApplicationUser>
    {
        private static string _connectionName;

        public ApplicationDbContext(string connectionName)
        {
            _connectionName = connectionName;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext("DefaultConnection");
        }
    }
}