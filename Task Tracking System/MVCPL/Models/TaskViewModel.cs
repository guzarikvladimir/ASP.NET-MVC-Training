using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCPL.Models
{
    public class TaskViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field can not be empty")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field can not be empty")]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Creation date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}")]
        [DataType(DataType.Date)]
        public DateTime CreationDateTime { get; set; }

        [Required(ErrorMessage = "The field can not be empty")]
        [Display(Name = "Deadline")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}")]
        [DataType(DataType.Date)]
        public DateTime DeadlineDate { get; set; }

        [Required(ErrorMessage = "The field can not be empty")]
        //[DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public TimeSpan DeadlineTime { get; set; }

        [Required(ErrorMessage = "The field can not be empty")]
        [ScaffoldColumn(false)]
        public int TotalPoints { get; set; }

        [ScaffoldColumn(false)]
        public int PointsCompleted { get; set; }

        [ScaffoldColumn(false)]
        public int StatusId { get; set; }

        [Display(Name = "Status:")]
        public string StatusName { get; set; }

        [Display(Name = "Users:")]
        public List<UserViewModel> Users { get; set; }
    }
}