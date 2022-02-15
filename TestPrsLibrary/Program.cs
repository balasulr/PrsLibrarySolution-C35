using PrsLibrary.Controllers;
using PrsLibrary.Models;

using System;
using System.Linq;

namespace TestPrsLibrary {
    
    class Program {
        
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        // Since use this line below, created to reduce the blocks of code with a method
        static void Print(Product product) {
            Console.WriteLine($"{product.Id,-5} {product.PartNbr,-12} {product.Name,-12} {product.Price,10:c} {product.Vendor.Name,-15}");
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////

        static void Main(string[] args) {
            ////////////////////////////////////////////////////////////////////////////////////////////////
            //// Login Method
            var context = new PrsDbContext();

            var userCtrl = new UsersController(context);

            var user = userCtrl.Login("sa", "sa");
            //var user = userCtrl.Login("sa", "sax"); // Will not work & say User not found

            if(user is null) {
                Console.WriteLine("User not found");
            } else {
                Console.WriteLine(user.Username);
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////


            ////////////////////////////////////////////////////////////////////////////////////////////////
            //var context = new PrsDbContext();

            //var username = "gdoud";
            //var password = "password";
            //// First Way
            //context.Users.SingleOrDefault (x => x.Username == username && x.Password == password);
            //// Second way
            //var user = from u in context.Users
            //        where u.Username == username && u.Password == password
            //        select u;

            ////////////////////////////////////////////////////////////////////////////////////////////////////


            ///////////////////////////////////////////////////////////////////////////
            //var reqlCtrl = new RequestLinesController(context);

            //var requestlines = reqlCtrl.GetAll();

            ///////////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////////////
            //// Creating Products Controller
            //var context = new PrsDbContext();

            //var prodCtrl = new ProductsController(context);

            //var products = prodCtrl.GetAll();

            //foreach(var p in products) {
            //    Print(p); // Calls the Console.WriteLine method in the Print above 
            //}

            //var product = prodCtrl.GetByPk(2);

            //if (product is not null) {
            //    Print(product);
            //}

            ////////////////////////////////////////////////////////////////////////////


            ///////////////////////////////////////////////////////////////////////////
            //var context = new PrsDbContext();

            //// Instance of the controller
            //var userCtrl = new UsersController(context);

            //// Calls the Create method to add a User
            //var newUser = new User() {
            //    Id = 0, Username = "zz", Password = "xx",
            //    Firstname = "User", Lastname = "ZZ",
            //    Phone = "211", Email = "xx@user.com",
            //    IsReviewer = false, IsAdmin = false
            //};

            ////userCtrl.Create(newUser); //// This line adds a user

            //var user3 = userCtrl.GetByPk(3);
            //if(user3 is null) {
            //    Console.WriteLine("User not found!");
            //} else {
            //    Console.WriteLine($"User 3: {user3.Firstname} {user3.Lastname}");
            //}

            //user3.Lastname = "User3";
            //userCtrl.Change(user3);
            /////////////////////////////////////////////////////////////////////////////////
            //var user33 = userCtrl.GetByPk(33);
            //if (user33 is null) {
            //    Console.WriteLine("User not found!");
            //} else {
            //    Console.WriteLine($"User33: {user3.Firstname} {user3.Lastname}");
            //}
            /////////////////////////////////////////////////////////////////////////////////

            ////userCtrl.Remove(6); // This line deleted the sixth instance oof the users

            //// Methods to get all users
            //var users = userCtrl.GetAll();

            //foreach(var user in users) {
            //    Console.WriteLine($"{user.Id} {user.Firstname} {user.Lastname}");
            //}
            ////////////////////////////////////////////////////////////////////////////////////////////////
        }
    }
}
