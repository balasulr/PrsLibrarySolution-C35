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
        ///////////////////////////////////////////////////////////////////////////////////
        private void RecalculateRequestTotal (int requestId) {
            var request = _context.Requests.Find(requestId); // To get 

            //// Doing a join with RequestLines and Products
            // Multiplies the Quantity from RequestLines and Price from Products
            // Set new Total Number
            request.Total = (from rl in _context.RequestLines // Getting all the Requestlines for all the requests
                             join p in _context.Products /// Joining requestlines to Products
                             on rl.ProductId equals p.Id // how put together with ProductId from RequestLines and ID from Products
                             where rl.RequestId == requestId // These rows where RequestId from RequestId matches the particular request
                             select new { // What some of the columns want to be outputted
                                 LineTotal = rl.Quantity * p.Price // Takes the 2 columns and multiply them together
                             }).Sum(x => x.LineTotal); // Taking the sum of all of the Line Totals and places it in request.Total
            _context.SaveChanges(); // Puts in database
        }
        ///////////////////////////////////////////////////////////////////////////////////


        ///////////////////////////////////////////////////////////////////////////////////
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
            RecalculateRequestTotal(requestline.RequestId); // Id of the request that the line added is coming from
            return requestline;
        }

        // 4 - Update
        public void Change(RequestLine requestline) {
            _context.SaveChanges();
            RecalculateRequestTotal(requestline.RequestId);
        }

        // 5. Delete
        public void Remove(int id) {
            var requestline = _context.RequestLines.Find(id);
            if (requestline is null) {
                throw new Exception("Requestline not found!");
            }
            _context.RequestLines.Remove(requestline);
            _context.SaveChanges();
            RecalculateRequestTotal(requestline.RequestId); // Recalculate after getting rid of a item
        }
    }
}
