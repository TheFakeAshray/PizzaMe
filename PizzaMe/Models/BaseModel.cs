using System.ComponentModel.DataAnnotations;


namespace PizzaMe.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}

//Would use this if everything used an ID as a key, but I don't think we are as Company can just use 'name' as a key.