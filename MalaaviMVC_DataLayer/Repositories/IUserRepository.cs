using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalaaviMVC_DomainClasses.Users;

namespace MalaaviMVC_DataLayer.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetUserByEmail(string email);
        User GetUserByActiveCode(string id);
        User GetUserByEmailAndPassword(string email, string pasword);
        string[] GetRoleByUserName(string username);
        User GetUserByUserName(string userName);
    }
}
