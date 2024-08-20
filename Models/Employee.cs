using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmployeesListWebForms.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmId { get; set; }

        [Required]
        public string EName { get; set; }

        public string Salary { get; set; }

        public string Department { get; set; }
    }
}