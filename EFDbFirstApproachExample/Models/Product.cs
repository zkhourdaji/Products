using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFDbFirstApproachExample.Models
{
    public class Product
    {
        [Key]
        [Display(Name ="Product ID")]
        public long ProductID { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Product Price")]
        public Nullable<decimal> Price { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Product purchase date")]
        public Nullable<System.DateTime> DateOfPurchase { get; set; }

        [Display(Name = "Availability Status")]
        public string AvailabilityStatus { get; set; }

        [Required(ErrorMessage = "Category Field is Required")]
        [Display(Name = "Category ID")]
        public long CategoryID { get; set; }

        [Required(ErrorMessage = "Brand Field is Required")]
        [Display(Name = "Brand ID")]
        public long BrandID { get; set; }

        [Display(Name = "Active")]
        public Nullable<bool> Active { get; set; }

        [Display(Name = "Product Photo")]
        public string Photo { get; set; }
        public Nullable<decimal> Quantity { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}