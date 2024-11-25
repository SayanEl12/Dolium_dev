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

        public bool Validate()
        {
            if (FrKey_Customer <= 0)
                return false;
            if (FrKey_Seller <= 0)
                return false;
            if (Date > DateTime.Today.AddDays(1))
                return false;
            if (Value <= 0)
                return false;
            if (Address is null || Address.Trim().Length == 0)
                return false;
            return true;
        }

    }
}

