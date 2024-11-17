using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace lib_entities
{
    [Keyless]
    public class Logs
    {
        public int FrKey_User { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
    }
}
