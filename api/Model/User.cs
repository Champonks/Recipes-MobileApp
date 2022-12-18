using System.ComponentModel.DataAnnotations;

namespace api.Model
{
    public class User
    {
        [Key]
        public string Login { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
    }
}