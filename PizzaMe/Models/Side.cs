using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PizzaMe.Models
{
    public class Side
    {
        [Key]
        public int SideID { get; set; }
        public string SideName { get; set; }
        public string SideDesc { get; set; }

        //Side can apply to many companies. 
        public ICollection<SideList> SideList { get; set; }
    }
}