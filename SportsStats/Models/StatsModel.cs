using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsStats.Models
{
    public class StatsModel
    {
        [Key]
        public int StatID { get; set; }

        public string StatType { get; set; }
        public double StatValue { get; set; }
        public int StatYear { get; set; }
        public string StatDesc { get; set; }
    }
}