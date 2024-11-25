using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_entities
{
    public class Smokers
    {
        [Key] public int Id { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Pounds { get; set; }
        public decimal Price_ref { get; set; }
        public string? Detail { get; set; }
        public int Stock { get; set; }

        public bool Validate()
        {
            if (Width != 0 || Height != 0)
            {
                if (Width > 60.0m || Height > 100.0m)
                    return false;
                if (Price_ref <= 0)
                    return false;
                if (Detail.Length >= 255)
                    return false;
                if (Stock <= 0)
                    return false;
            }
            return true;
        }
    }
}

