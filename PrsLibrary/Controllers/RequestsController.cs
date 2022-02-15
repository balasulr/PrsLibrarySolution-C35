using Microsoft.EntityFrameworkCore;
using PrsLibrary.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsLibrary.Controllers {
    
    public class RequestsController {

        private readonly PrsDbContext _context;

        // Constructor
        public RequestsController(PrsDbContext context) {
            _context = context;
        }

        //// 5 Methods/ Functions
        // 1. Get all Requests
        public IEnumerable<Request> GetAll() {
            return _context.Requests.Include(x => x.User).ToList();
        }

        // 2. Get Product by Primary Key
        public Request GetByPk(int id) {
            return _context.Requests.Include(x => x.User)
                .SingleOrDefault(x => x.Id == id);
        }

        // 3. Insert Statement
        public Request Create(Request request) {
            if (request is null) {
                throw new ArgumentNullException("request");
            }
            if (request.Id != 0) {
                throw new ArgumentException("Request.Id must be zero!");
            }
            _context.Requests.Add(request);
            _context.SaveChanges();
            return request;
        }

        // 4 - Update
        public void Change(Request request) {
            _context.SaveChanges();
        }

        // 5. Delete
        public void Remove(int id) {
            var Request = _context.Requests.Find(id);
            if (Request is null) {
                throw new Exception("Request not found!");
            }
            _context.Requests.Remove(Request);
            _context.SaveChanges();
        }
    }
}
