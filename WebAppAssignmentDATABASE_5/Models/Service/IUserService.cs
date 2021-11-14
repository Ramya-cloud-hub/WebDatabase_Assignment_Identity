using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppAssignmentDATABASE_5.Models.ViewModels;

namespace WebAppAssignmentDATABASE_5.Models.Service
{
    public interface IUserService
    { 
        UserViewModel Add(CreateUserViewModel person);

        UsersViewModel All();

        UserViewModel FindBy(string userName);

        UserViewModel Edit(string id, CreateUserViewModel person);

        bool Remove(int id);

        void AddRole(string userName, string role);
        bool Login(LoginViewModel login);

        void Logout();
    }
}
