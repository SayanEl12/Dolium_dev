using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace lib_entities
{
    [Keyless]
    public class Sale_Productcs
    {
        public int FrKey_Sale { get; set; }
        public int FrKey_Smoker { get; set; }
        public int Cant { get; set; }
    
    }
}
