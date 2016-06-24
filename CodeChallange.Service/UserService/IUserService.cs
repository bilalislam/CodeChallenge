using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CodeChallange.Entity;

namespace CodeChallange.Service.UserService
{
    public interface IUserService
    {
        List<User> ListUser(int skip, int take, Expression<Func<User, string>> orderBy);
        void AddUser(User model);
        void UpdateUser(User model);
        void DeleteUser(int id);
        User GetUser(int id);
        int GetTotalCount();
    }
}