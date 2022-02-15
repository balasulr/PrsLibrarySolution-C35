using PrsLibrary.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsLibrary.Controllers {

    public class VendorsController {

        private readonly PrsDbContext _context;

        // Constructor
        public VendorsController(PrsDbContext context) {
            _context = context;
        }

        //// 5 Methods/ Functions
        // 1. Get all Vendors
        public IEnumerable<Vendor> GetAll() {
            return _context.Vendors.ToList();
        }

        // 2. Get Vendor by Primary Key
        public Vendor GetByPk(int id ) {
            return _context.Vendors.Find(id);
        }

        // 3. Inserting Vendor
        public Vendor Create(Vendor vendor) {
            _context.Vendors.Add(vendor); // Adds to the EF cache
            _context.SaveChanges();

            return vendor; // To see what id was assigned to the Vendor
        }

        // 4 - Update
        public void Change(Vendor vendor) {
            _context.SaveChanges();
        }

        // 5 - Delete
        public void Remove(int id) {
            var vendor = _context.Vendors.Find(id);
            if(vendor is not null) {
                _context.Vendors.Remove(vendor);
                _context.SaveChanges();
            }
        }
    }
}
