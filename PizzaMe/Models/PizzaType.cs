using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PizzaMe.Models
{
    public class PizzaType
    {
        [Key]
        public int PizzaTypeID { get; set; }
        public string TypeName { get; set; }
        public decimal PriceRangeMin { get; set; }
        public decimal PriceRangeMax { get; set; }
        public int MaxIngredients { get; set; }

        public ICollection<PizzaTypeList> PizzaTypeList { get; set; }
        public ICollection<PizzaTypeCompany> PizzaTypeCompany { get; set; }

    }
}