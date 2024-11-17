using System.ComponentModel.DataAnnotations;

namespace lib_entities
{
    public class Sales
    {
        [Key] public int Id { get; set; }
        public int  FrKey_Customer { get; set; }
        public int  FrKey_Seller { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public string? Address { get; set; }

    }
}

