using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PizzaMe.Models
{
    public class Coupon
    {
        [Key]
        public int CouponID { get; set; }
        public string CouponName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Boolean Delivery { get; set; }

        public string CouponCode { get; set; }

        public CouponType CouponType { get; set; }

        //If CouponType is Percentage
        public int PercentDisc { get; set; }
        
        //If CouponType is TwoForOne
        public int PriceTwoForOne { get; set; }
        public int NoOfPizzasTwoForOne { get; set; }

        //If CouponType is FixedDiscount
        public int FixedDisc { get; set; }
        public int MinPriceFixedDisc { get; set; }

        //Lel Sides
        public int NoOfSides { get; set; }
        public ICollection<Side> Sides { get; set; }

        //Coupon may apply to many Branches
        public ICollection<CouponRelation> CouponRelations { get; set; }


        //Types of pizzas this coupon applies to
        public ICollection<PizzaTypeList> PizzaTypeList { get; set; }
    }

    public enum CouponType
    {
        PercentDiscount,
        FixedDiscount,
        TwoForOneDiscount
    }
}