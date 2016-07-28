using System.ComponentModel.DataAnnotations;
using Shared.Models.Interfaces;

namespace Shared.Models.Tables
{
    public class Employee : IEmployee
    {
        public int EmployeeId { get; set; }

        [Required, Display(Name = "Employee Number")]
        public string EmployeeNumber { get; set; }

        [Required, Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string LastName { get; set; }

        [Required, Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string FirstName { get; set; }

        [Required, Display(Name = "MI")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        public string MiddleName { get; set; }
    }
}
