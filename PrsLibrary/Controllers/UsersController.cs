using PrsLibrary.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsLibrary.Controllers {

    public class UsersController {
        // Private Property for Context
        private readonly PrsDbContext _context; // readonly is a safetynet. Only way that can set is in the contructor

        public UsersController(PrsDbContext context) { // Constructor
            this._context = context;
        }

        // 2 Read fuctions
        // Method to return all of the users in the User Table
        public IEnumerable<User> GetAll() {
            return _context.Users.ToList(); // Returns all users in a List
        }

        // Allow user to read by primary key (Most that can read is 1)
        // Returns the user instance or null
        public User GetByPk(int id) {
            return _context.Users.Find(id);
        }

        // Insert Statement
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

        // Update - Change some of the data for a user
        public void Change(User user) {
            _context.SaveChanges();
        }

        // Delete where the user passes in the primary key
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
