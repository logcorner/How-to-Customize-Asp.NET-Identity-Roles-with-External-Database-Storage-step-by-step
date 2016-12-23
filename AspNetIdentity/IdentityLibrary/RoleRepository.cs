using IdentityLibrary.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IdentityLibrary
{
    internal class RoleRepository<T> where T : IdentityRole
    {
        private readonly DatabaseContext _databaseContext;

        public RoleRepository(DatabaseContext dataBaseContext)
        {
            _databaseContext = dataBaseContext;
        }

        internal IQueryable<T> GetRoles()
        {
            List<T> result = (List<T>)Activator.CreateInstance(typeof(List<T>));
            var roles = _databaseContext.AspNetRoles.ToList();
            foreach (var role in roles)
            {
                T item = (T)Activator.CreateInstance(typeof(T));
                item.Id = role.Id;
                item.Name = role.Name;
                item.Description = role.Description;
                result.Add(item);
            }
            return result.AsQueryable();
        }

        internal void Dispose()
        {
            _databaseContext.Dispose();
        }

        internal int Create(T role)
        {
            _databaseContext.AspNetRoles.Add(new AspNetRoles
            {
                Id = role.Id,
                Description = role.Description,
                Name = role.Name
            });
            return _databaseContext.SaveChanges();
        }

        internal int Delete(string id)
        {
            var existingRole = _databaseContext.AspNetRoles.Find(id.Trim());
            if (existingRole != null)
            {
                _databaseContext.Entry(existingRole).State = EntityState.Deleted;
                return _databaseContext.SaveChanges();
            }
            return -1;
        }

        internal T FindByNamec(string roleName)
        {
            var role = _databaseContext.AspNetRoles.FirstOrDefault(r => r.Name == roleName.Trim());
            if (role == null)
            {
                return default(T);
            }
            T item = (T)Activator.CreateInstance(typeof(T));
            item.Id = role.Id;
            item.Name = role.Name;
            item.Description = role.Description;
            return item;
        }

        internal T FindById(string roleId)
        {
            var role = _databaseContext.AspNetRoles.Find(roleId.Trim());
            if (role == null)
            {
                return default(T);
            }
            T item = (T)Activator.CreateInstance(typeof(T));
            item.Id = role.Id;
            item.Name = role.Name;
            item.Description = role.Description;
            return item;
        }

        internal int Update(T role)
        {
            var existingRole = _databaseContext.AspNetRoles.Find(role.Id.Trim());
            if (existingRole != null)
            {
                existingRole.Name = role.Name;
                existingRole.Description = role.Description;
                _databaseContext.Entry(existingRole).State = EntityState.Modified;
                return _databaseContext.SaveChanges();
            }
            return -1;
        }
    }
}