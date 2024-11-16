using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_services
{
    internal class Images
    {
        [Key] public int Id { get; set; }
        public int  Id_Smoker { get; set; }
        public string? Url { get; set; }
    
    }
}
