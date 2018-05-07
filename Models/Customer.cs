using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RdoCallLogger.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public string Location { get; set; }
        public string WorkPhone { get; set; }
        public string CellPhone { get; set; }
        public string EmailID { get; set; }

        [Required]
        [Display(Name = "Farm Name")]
        public int FarmID { get; set; }

        [ForeignKey("FarmID")]
        public Farm Farm { get; set; }
    }

    public class CustomerSearch
    {
        static public string SearchOptionString = "SearchOption";

        public string SearchOption { get; set; }
        public string Keyword { get; set; }

        static public List<string> AvailableOptions()
        {
            List<string> options = new List<string>();
            options.Add("Phone Number");
            options.Add("Farm Name");

            return options;
        }
    }
}