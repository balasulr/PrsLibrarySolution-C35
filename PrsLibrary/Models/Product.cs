using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrsLibrary.Models {

    public class Product {

        public int Id { get; set; }
        [Required,StringLength(30)]
        public string PartNbr { get; set; }
        [Required, StringLength(30)]
        public string Name { get; set; }
        [Column(TypeName = "decimal(11,2)")]
        public decimal Price { get; set; }
        [Required, StringLength(30)]
        public string Unit { get; set; }
        [StringLength(255)]
        public string PhotoPath { get; set; }

        public int VendorId { get; set; }
        // Virtual Instance required for EF to
        // recognize the FK
        public virtual Vendor Vendor { get; set; } // The second Vendor can be anything. Doesn't have to be the same

        public Product() { } // Default Constructor
    }

}
