using MalaaviMVC_DomainClasses.Users;
using MalaaviMVC_ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalaaviMVC_Business
{
    public interface IUserServices
    {
        User InsertUserService(RegisterViewModel register);
        User ActiveUserService(string id);
    }
}
