using MalaaviMVC_DataLayer.Context;
using MalaaviMVC_DomainClasses.Users;
using MalaaviMVC_ViewModels;
using System;
using System.Web.Security;

namespace MalaaviMVC_Business
{
    public class UserServices : IUserServices
    {
        private UnitOfWork _uow = new UnitOfWork();

        // Insert New User => Register
        public User InsertUserService(RegisterViewModel register)
        {
            if (_uow.UserRepository.GetUserByEmail(register.Email.Trim().ToLower()) == null)
            {
                User user = new User()
                {
                    Email = register.Email.Trim().ToLower(),
                    ActiveCode = Guid.NewGuid().ToString(),
                    IsActive = false,
                    Password = FormsAuthentication.HashPasswordForStoringInConfigFile(register.Password, "MD5"),
                    RegisterDate = DateTime.Now,
                    RoleId = 1,
                    UserName = register.UserName
                };
                _uow.UserRepository.Insert(user);
                _uow.Save();
                return user;
            }
            else
            {
                return null;
            }
        }

        // Activation User 
        public User ActiveUserService(string id)
        {
            var user = _uow.UserRepository.GetUserByActiveCode(id);
            if (user != null)
            {
                user.IsActive = true;
                user.ActiveCode = Guid.NewGuid().ToString();
                _uow.UserRepository.Update(user);
                _uow.Save();
                return user;
            }
            else
            {
                return null;
            }
        }

    }
}
