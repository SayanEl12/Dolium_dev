using lib_services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace lib_services
{
    internal class Sales
    {
        [Key] public int Id { get; set; }
        public int  FrKey_Customer { get; set; }
        public int  FrKey_Seller { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public string? Address { get; set; }

    }
}

