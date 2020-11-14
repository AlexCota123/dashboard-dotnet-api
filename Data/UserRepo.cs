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
            //var users = new List<User>
            //{
            //    new User{Id = 0, Name = "Alejandro", LastName = "Cota", Age = 23},
            //    new User{Id = 1, Name = "Luci", LastName = "Diamonds", Age = 24 },
            //    new User{Id=2, Name="Jose", LastName="Aguirre", Age =26}
            //};
           

            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            //return new User
            //{
            //    Id = 0,
            //    Name = "Alejandro",
            //    LastName = "Cota",
            //    Age = 23
            //};

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
    }
}
