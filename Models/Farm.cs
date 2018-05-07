using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RdoCallLogger.Models
{
    public class Farm
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Farm Name")]
        public string Name { get; set; }

        [Display(Name = "Farm Location")]
        public string Location { get; set; }

        public Subscription Subscription { get; set; }

        public List<Case> Cases { get; set; }
        public List<Customer> Customers { get; set; }
    }

    [ComplexType]
    public class Subscription
    {
        [Display(Name = "Subscription Count")]
        public int Count { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Subscription Start Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Subscription Expiration Date")]
        public DateTime ExpirationDate { get; set; }
    }
}