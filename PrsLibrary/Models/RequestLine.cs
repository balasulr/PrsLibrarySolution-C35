using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsLibrary.Models {

    public class RequestLine {

        public int Id { get; set; }
        public int Quantity { get; set; }

        // Setting up foreign keys
        public int RequestId { get; set; }
        public virtual Request Request { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        
        public RequestLine() { }
    }
}
