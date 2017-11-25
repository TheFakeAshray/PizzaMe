using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaMe.Models
{
    public class SideList
    {
        [Key, Column(Order = 1)]
        public int SideID { get; set; }
        public Side Side { get; set; }

        [Key, Column(Order = 2)]
        public string CompanyName { get; set; }
        public Company Company { get; set; }
    }
}
