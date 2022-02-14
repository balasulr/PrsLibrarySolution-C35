using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsLibrary.Models {

    public class User {
        // Adding Properties to class
        public int Id { get; set; }
        [Required,StringLength(30)] // Attributes combined in one line & makes sure defined properly in SQL
        public string Username { get; set; }
        [Required, StringLength(30)] // Sets the Password having the Null be No so is not allowed to be null/ not null
        public string Password { get; set; }
        [Required, StringLength(30)]
        public string Firstname { get; set; }
        [Required, StringLength(30)]
        public string Lastname { get; set; }
        [StringLength(12)] // Phone is Yes for null and same for Email
        public string Phone { get; set; }
        [StringLength(255)]
        public string Email { get; set; }
        public bool IsReviewer { get; set; }
        public bool IsAdmin { get; set; }

        // Adding a default constructor on one line to save space
        public User() { }
    }
}
