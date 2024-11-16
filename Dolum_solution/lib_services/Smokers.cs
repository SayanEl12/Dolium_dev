using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_services
{
    internal class Smokers
    {
        [Key] public int Id { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Pounds { get; set; }
        public decimal Price_ref { get; set; }
        public string? Detail { get; set; }
        public int Stock { get; set; }
    }
}

