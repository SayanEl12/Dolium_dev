using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace lib_entities
{
    
    public class Sale_Product
    {
        [Key] public int Id { get; set; }
        public int FrKey_Sale { get; set; }
        public int FrKey_Smoker { get; set; }
        public int Cant { get; set; }
    
    }
}
