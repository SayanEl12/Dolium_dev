using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_entities
{
    public class Users
    {
        [Key] public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email{ get; set; }
        public int Quality { get; set; }
        public string? Password { get; set; }
        public DateTime Register_date { get; set; }
        public bool Validate()
        {
            
            if (string.IsNullOrWhiteSpace(Name) || Name.Length > 100)
                return false;
            if (string.IsNullOrWhiteSpace(Email) ||
                !Email.Contains("@") ||
                Email.Length > 100)
                return false;
            if (Quality < 0)
                return false;
            if (string.IsNullOrWhiteSpace(Password) || Password.Length > 100)
                return false;
            if (Register_date > DateTime.Today)
                return false;

            return true;
        }

    }

}
