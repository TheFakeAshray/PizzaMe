using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaMe.Models
{
    public class CouponRelation
    {
        [Key, Column(Order = 1)]
        public int BranchID { get; set; }
        public Branch Branch { get; set; }

        [Key, Column(Order = 2)]
        public int CouponID { get; set; }
        public Coupon Coupon { get; set; }
    }
}