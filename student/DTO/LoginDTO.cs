using System.ComponentModel.DataAnnotations;

namespace student.DTO
{
    public class LoginDTO
    {
        [Required]
         public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
