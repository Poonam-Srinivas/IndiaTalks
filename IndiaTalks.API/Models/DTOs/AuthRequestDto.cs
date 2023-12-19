using System.ComponentModel.DataAnnotations;

namespace IndiaTalks.API.Models.DTOs
{
    public class AuthRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Password { get; set; }

    }
}
