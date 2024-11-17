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
    }
}
