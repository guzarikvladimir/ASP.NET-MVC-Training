namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Exception
    {
        public int Id { get; set; }

        [Required]
        public string ExceptionMessage { get; set; }

        [Required]
        public string ControllerName { get; set; }

        [Required]
        public string ActionName { get; set; }

        [Required]
        public string StackTrace { get; set; }

        public DateTime Date { get; set; }
    }
}
