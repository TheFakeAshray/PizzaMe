using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzaMe.Models
{
    public class Branch
    {
        [Key]
        public int BranchID { get; set; }
        public string Address { get; set; }
        public string BranchName { get; set; }

        //Foreign Key
        public string CompanyName { get; set; }

        public Company Company { get; set; }

        //Relation
        public ICollection<CouponRelation> CouponRelations { get; set; }
    }
}