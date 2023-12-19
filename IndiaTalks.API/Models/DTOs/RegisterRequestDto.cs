using System.ComponentModel.DataAnnotations;

namespace IndiaTalks.API.Models.DTOs
{
    public class RegisterRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Password { get; set; }

        public string[] Roles { get; set; }
    }
}
