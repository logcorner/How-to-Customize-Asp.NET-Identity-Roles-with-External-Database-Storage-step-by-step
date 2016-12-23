using IdentityLibrary.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IdentityLibrary
{
    internal class UserRolesRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRolesRepository(DatabaseContext database)
        {
            _databaseContext = database;
        }

        /// <summary>
        /// Returns a list of user's roles
        /// </summary>
        /// <param name="userId">The user's id</param>
        /// <returns></returns>
        public IList<string> FindByUserId(string userId)
        {
            var roles = _databaseContext.AspNetUsers.
                Where(u => u.Id == userId).SelectMany(r => r.AspNetRoles);
            return roles.Select(r => r.Name).ToList();
        }

        internal bool IsInRole(string id, string roleName)
        {
            return _databaseContext.AspNetRoles.Any(u => u.AspNetUsers.Any(x => x.Id == id));
        }
    }
}