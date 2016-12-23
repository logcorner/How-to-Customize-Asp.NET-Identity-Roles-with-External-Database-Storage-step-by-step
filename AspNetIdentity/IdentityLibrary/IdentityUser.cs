namespace IdentityLibrary
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;

    /// <summary>
    /// Class that implements the ASP.NET Identity
    /// IUser interface
    /// </summary>
    public class IdentityUser : IdentityUser<string,
                                IdentityUserLogin,
                                IdentityUserRole,
                                IdentityUserClaim>, IUser
    {
        public IdentityUser()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}