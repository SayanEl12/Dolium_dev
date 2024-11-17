using System.ComponentModel.DataAnnotations;

namespace lib_entities
{
    public class Images
    {
        [Key] public int Id { get; set; }
        public int  Id_Smoker { get; set; }
        public string? Url { get; set; }
    
    }
}
