using System.ComponentModel.DataAnnotations;

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
            if (!string.IsNullOrEmpty(Name))
            {
                if (Name.Length > 100)
                    return false;
            }
            if (!string.IsNullOrEmpty(Email))
            {
                if (!Email.Contains("@") || Email.Length > 100)
                    return false;
            }
            if (Quality < 0)
                return false;
            if (!string.IsNullOrEmpty(Password))
            {
                if (Password.Length > 100 || Password.Length == 0)
                return false;
            }
            if (Register_date > DateTime.Today.AddDays(1))
                return false;
            return true;
        }

    }

}
