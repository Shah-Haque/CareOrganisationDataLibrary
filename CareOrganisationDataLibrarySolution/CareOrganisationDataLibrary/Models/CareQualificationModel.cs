using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareOrganisationDataLibrary.Models
{
    public class CareQualificationModel
    {
        public int QualificationID { get; set; }

        [Required]
        [DisplayName("staff member")]
        public int StaffID { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "the name of the Qualification must be below 50 characters")]
        [MinLength(3, ErrorMessage = "You need to enter at least 3 characters for the name of the qualification")]
        [DisplayName("Qualification Name")]
        public string QualificationType { get; set; }

        [Required]
        [DisplayName("Qualification Grade")]
        public string Grade { get; set; }

        [Required]
        [DisplayName("Date Achieved for qualification")]
        public DateTime AttainmentDate { get; set; }
    }
}