using System;
using System.Collections.Generic;
using Dashboard.Models;

namespace Dashboard.Data
{
    public interface IUserRepo
    {
        bool SaveChanges();
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
