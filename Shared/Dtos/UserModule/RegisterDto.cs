using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos.UserModule
{
    public class RegisterDto
    {
        [EmailAddress(ErrorMessage ="Enter a Valid Email")]
        [Required(ErrorMessage = "Email Is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "FullName Is Required")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "Age Is Required")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender Is Required")]
        public string Gender { get; set; } = null!;

        [Required(ErrorMessage = "Country Is Required")]
        public string Country { get; set; } = null!;

        [Required(ErrorMessage = "City Is Required")]
        public string City { get; set; } = null!;

        //[Required(ErrorMessage = "LevelId Is Required")]
        public Guid? LevelId { get; set; }

        [Required(ErrorMessage = "PhoneNumber Is Required")]
        public string PhoneNumber { get; set; }
    }
}
