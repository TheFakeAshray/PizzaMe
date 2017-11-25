using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaMe.Models
{
    public class PizzaTypeList
    {
        [Key, Column(Order = 1)]
        public int CouponID { get; set; }
        public Coupon Coupon { get; set; }

        [Key, Column(Order = 2)]
        public string PizzaTypeID { get; set; }
        public PizzaType PizzaType { get; set; }
    }
}