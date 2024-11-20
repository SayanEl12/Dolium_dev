using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace lib_entities
{
  
    public class Logs
    {
        [Key]public int Id { get; set; }
        public int FrKey_User { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public bool Validate()
        {
            if (FrKey_User <= 0)
                return false;
            if (string.IsNullOrWhiteSpace(Description) || Description.Length > 255)
                return false;
            if (Date > DateTime.Today)
                return false;
            return true;
        }
    }
}
