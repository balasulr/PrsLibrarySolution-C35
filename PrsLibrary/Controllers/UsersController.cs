using PrsLibrary.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsLibrary.Controllers {

    public class UsersController {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Private Property for Context
        private readonly PrsDbContext _context; // readonly is a safety net. Only way that can
                                                // be set is in the contructor

        // Constructor
        public UsersController(PrsDbContext context) {
            this._context = context;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Login Method
        public User Login(string username, string password) {
            // Method syntax
            return _context.Users
                            .SingleOrDefault(x => x.Username == username
                                                    && x.Password == password);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //// 2 Read fuctions then have Insert, Update & Delete

        // 1. Method to return all of the users in the User Table
        public IEnumerable<User> GetAll() {
            return _context.Users.ToList(); // Returns all users in a List
        }

        // 2. Allow user to read by primary key (Most that can read is 1)
        // Returns the user instance or null
        public User GetByPk(int id) {
            return _context.Users.Find(id);
        }

        // 3. Insert Statement
        public User Create(User user) {
            if(user is null) {
                throw new ArgumentNullException("user");
            }
            if(user.Id != 0) {
                throw new ArgumentException("User.Id must be zero!");
            }
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        // 4. Update - Change some of the data for a user
        public void Change(User user) {
            _context.SaveChanges();
        }

        // 5. Delete
        // User passes in a primary key that wants to delete
        public void Remove(int id) {
            var user = _context.Users.Find(id);
            if(user is null) {
                throw new Exception("User not found!");
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
