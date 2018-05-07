using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RdoCallLogger.Models
{
    public class Case
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Problem Statement")]
        public string CaseTitle { get; set; }

        [Required]
        [Display(Name = "Problem Description")]
        public string CaseDescription { get; set; }

        [Required]
        [Display(Name = "Farm Name")]
        public int FarmID { get; set; }

        [ForeignKey("FarmID")]
        public Farm Farm { get; set; }

        public List<Solution> Solutions { get; set; }
    }

    // This class manages paging related variables and helps
    // to add paging functionality to WebGrid
    public class PagedCases
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public List<Case> Cases { get; set; }
        public int TotalRows { get; set; }

        public PagedCases(List<Case> cases, int pageSize=10, int pageNumber=1, int totalRows=1)
        {
            Cases = cases;
            PageSize = pageSize;
            PageNumber = pageNumber;
            TotalRows = totalRows;
        }
    }
}