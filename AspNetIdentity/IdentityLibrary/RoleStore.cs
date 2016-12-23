using IdentityLibrary.DataModel;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityLibrary
{
    /// <summary>
    /// Class that implements the key ASP.NET Identity role store iterfaces
    /// </summary>
    public class RoleStore<TRole> : IQueryableRoleStore<TRole>
    where TRole : IdentityRole
    {
        private readonly RoleRepository<TRole> _roleRepository;

        public RoleStore(DatabaseContext databaseContext)
        {
            _roleRepository = new RoleRepository<TRole>(databaseContext);
        }

        public IQueryable<TRole> Roles
        {
            get
            {
                return _roleRepository.GetRoles();
            }
        }

        public Task CreateAsync(TRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }
            return Task.Run(() => _roleRepository.Create(role));
        }

        public Task DeleteAsync(TRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }

            return Task.Run(() => _roleRepository.Delete(role.Id));
        }

        public Task<TRole> FindByIdAsync(string roleId)
        {
            if (roleId == null)
            {
                throw new ArgumentNullException("roleId");
            }

            return Task.Run(() => _roleRepository.FindById(roleId));
        }

        public Task<TRole> FindByNameAsync(string roleName)
        {
            if (roleName == null)
            {
                throw new ArgumentNullException("roleName");
            }

            return Task.Run(() => _roleRepository.FindByNamec(roleName));
        }

        public Task UpdateAsync(TRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }
            return Task.Run(() => _roleRepository.Update(role));
        }

        public void Dispose()
        {
            _roleRepository.Dispose();
        }
    }
}