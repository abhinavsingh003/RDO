using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RdoCallLogger.Models
{
    public class Solution
    {
        public int ID { get; set; }

        [Required]
        public string SolutionTitle { get; set; }

        [Required]
        public string SolutionDescription { get; set; }

        public List<Case> Cases { get; set; }
    }
}