using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FSTA.Models.ViewModel
{
    public class TourLeaderDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Rank { get; set; } //M1, M2, M3, PT
       
    }
}