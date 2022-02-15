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
            this._context = context;
        }

        // Method to look in Requests table for Reviewed status
        // where it is not for the reviewer since reviewer should not review their own
        public IEnumerable<Request> GetRequestsInReview(int userId) {
            // Query syntax
            var requests = _context.Requests
                                        .Where(x => x.Status == "REVIEW"
                                                && x.UserId != userId)
                                                .ToList();
            return requests;
        }

        // Unconditionally sets to Rejected
        public void SetRejected(Request request) {
            request.Status = "REJECTED";
            Change(request);
        }

        //// Methods to set status of request to Approve or Review

        // If total of the request is less than or equal to $50, sets Approved
        // Unconditionally sets to Approved
        public void SetApproved(Request request) {
            request.Status = "APPROVED";
            Change(request);
        }

        // Sets status of Request to Review or Approved (if less than or equal to $50)
        public void SetReview(Request request) {
            if(request.Total <= 50) {
                request.Status = "APPROVED";
            } else {
                request.Status = "REVIEW";
            }
            Change(request);
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
