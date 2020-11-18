using System;
using System.Collections.Generic;
using System.Linq;
using Dashboard.Models;

namespace Dashboard.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly DashboardContext _context;

        public UserRepo(DashboardContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id);
        }

        public bool SaveChanges()
        {
            return ( _context.SaveChanges() >= 0 );
        }

        public void CreateUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Add(user);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);

        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }
    }
}
