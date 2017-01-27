using System.ComponentModel.DataAnnotations;

namespace MVCPL.Models
{
    public class LogOnViewModel
    {
        [Required(ErrorMessage = "The field can not be empty")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Incorrect email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The field can not be empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}