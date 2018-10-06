using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalaaviMVC_DataLayer.Context;
using MalaaviMVC_DataLayer.Repositories;
using MalaaviMVC_DomainClasses.Users;

namespace MalaaviMVC_DataLayer.Services
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private DataContext _context;
        private DbSet<User> _dbSet;
        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<User>();
        }

        public User GetUserByEmail(string email)
        {
            return _dbSet.SingleOrDefault(a => a.Email == email);
        }

        public User GetUserByActiveCode(string id)
        {
            return _dbSet.SingleOrDefault(a => a.ActiveCode == id);
        }

        public User GetUserByEmailAndPassword(string email, string pasword)
        {
            return _dbSet.SingleOrDefault(u => u.Email == email && u.Password == pasword);
        }

        public string[] GetRoleByUserName(string username)
        {
            return _dbSet.Where(u => u.UserName == username).Select(u => u.Role.Name).ToArray();
        }

        public User GetUserByUserName(string userName)
        {
            return _dbSet.Single(u => u.UserName == userName);
        }
    }
}
