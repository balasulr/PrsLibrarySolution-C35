using Microsoft.EntityFrameworkCore;

using PrsLibrary.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsLibrary.Controllers {

    public class RequestLinesController {
        private readonly PrsDbContext _context;
        // Constructor
        public RequestLinesController(PrsDbContext context) {
            _context = context;
        }

        //// 5 Methods/ Functions
        // 1. Get all Requests
        public IEnumerable<RequestLine> GetAll() {
            return _context.RequestLines
                .Include(x => x.Product)
                .Include(x => x.Request)
                .ToList();
        }

        // 2. Get by Primary Key
        public RequestLine GetByPk(int id) {
            return _context.RequestLines
                .Include(x => x.Product)
                .Include(x => x.Request)
                .SingleOrDefault(x => x.Id == id);
        }

        // 3. Insert Statement
        public RequestLine Create(RequestLine requestline) {
            if (requestline is null) {
                throw new ArgumentNullException("requestline");
            }
            if (requestline.Id != 0) {
                throw new ArgumentException("Requestline.Id must be zero!");
            }
            _context.RequestLines.Add(requestline);
            _context.SaveChanges();
            return requestline;
        }

        // 4 - Update
        public void Change(RequestLine requestline) {
            _context.SaveChanges();
        }

        // 5. Delete
        public void Remove(int id) {
            var requestline = _context.RequestLines.Find(id);
            if (requestline is null) {
                throw new Exception("Requestline not found!");
            }
            _context.RequestLines.Remove(requestline);
            _context.SaveChanges();
        }
    }
}
