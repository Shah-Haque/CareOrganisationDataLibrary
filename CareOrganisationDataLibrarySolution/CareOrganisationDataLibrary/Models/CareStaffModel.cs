using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareOrganisationDataLibrary.Models
{
    public class CareStaffModel
    {
        public int StaffID { get; set; }

        [Required]
        [DisplayName("Care Homes")]
        public int CareHomeID { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "You need to enter at least 3 characters for your First Name")]
        [DisplayName("Staff First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "You need to enter at least 3 characters for your Last Name")]
        [DisplayName("Staff Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "You need to enter at least 3 characters for your job title")]
        [DisplayName("Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [DisplayName("Annual Salary")]
        public decimal AnnualSalary { get; set; }

    }
}