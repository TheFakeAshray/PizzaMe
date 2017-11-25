using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;



namespace PizzaMe.Models
{
    public class Company
    {
        [Key]
        public string CompanyName { get; set; }
        public string CompanyDesc { get; set; }

        //Company has many branches
        public ICollection<Branch> Branches{ get; set; }

        //Company has many sides
        public ICollection<SideList> SideList { get; set; }

        //Company has many Pizza Types (Value, Favourites Etc)
        public ICollection<PizzaTypeCompany> PizzaTypeCompany { get; set; }

    }
}