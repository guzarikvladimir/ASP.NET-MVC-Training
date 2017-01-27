using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCPL.Models
{
    public class UserViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "User's e-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "User's password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Date of registration")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}")]
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }

        [ScaffoldColumn(false)]
        public int RoleId { get; set; }

        [Display(Name = "User's role")]
        public string Role { get; set; }

        [Display(Name = "User's tasks")]
        public List<TaskViewModel> Tasks { get; set; }
    }
}