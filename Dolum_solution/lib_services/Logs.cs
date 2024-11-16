using System.ComponentModel.DataAnnotations;

namespace lib_services
{
    internal class Logs
    {
        public int FrKey_User { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
    }
}
