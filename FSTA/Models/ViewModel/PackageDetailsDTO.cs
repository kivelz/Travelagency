using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FSTA.Models.ViewModel
{
    public class PackageDetailsDTO
    {
        public int Id { get; set; }
        public string PackageName { get; set; }
        public string TourLeaderName { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime EndDate { get; set; }
      
    }
}