using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using CodeChallange.Entity;
using CodeChallenge.Data.CoreRepository;
using CodeChallenge.Data.UserRepository;

namespace CodeChallange.Service.UserService
{
    public class UserService : IUserService
    {
        protected readonly IRepository<User> _repository;
        protected readonly IUserRepository _userRepository;

        public UserService(IRepository<User> repository, IUserRepository userRepository)
        {
            _repository = repository;
            _userRepository = userRepository;
        }

        public List<User> ListUser(int skip, int take, Expression<Func<User, string>> orderBy)
        {
            return _repository.Select(skip, take, orderBy).ToList();
        }

        public void AddUser(User model)
        {
            model.CreateDate = DateTime.Now;
            _repository.Add(model);
        }

        public void UpdateUser(User model)
        {
            model.UpdateDate = DateTime.Now;
            _repository.Update(model);
        }

        public void DeleteUser(int id)
        {
            var user = _repository.Get(x => x.ID == id);
            _repository.Delete(user);
        }

        public User GetUser(int id)
        {
            return _repository.Get(x => x.ID == id);
        }

        public int GetTotalCount()
        {
            return _userRepository.GetTotalCount();
        }
    }
}
