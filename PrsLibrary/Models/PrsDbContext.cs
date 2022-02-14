using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsLibrary.Models {

    public class PrsDbContext : DbContext {
        
        public virtual DbSet<User> Users { get; set; } // Adding Class so will show up in the migration
        public virtual DbSet<Vendor> Vendors { get; set; }

        // Constructors
        public PrsDbContext() { } // Default Constructor with no parameters
        public PrsDbContext(DbContextOptions<PrsDbContext> options) : base(options) { }

        //Methods
        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            if(!builder.IsConfigured) {
                builder.UseSqlServer(
                    "server=localhost\\sqlexpress;database=TestPrsDb;trusted_connection = true;"
               );
            }
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            // Makes Username in User unique
            builder.Entity<User>(e => { // User is the name of Class
                e.HasIndex(p => p.Username).IsUnique(true); // Column that want a index on is Username
            });

            // Makes Code column unique
            builder.Entity<Vendor>(e => {
                e.HasIndex(p => p.Code).IsUnique(true);
            });
        }
    }
}
