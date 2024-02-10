using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareOrganisationDataLibrary.Models
{
    public class CareHomesModel
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "the name of the Care Home must be below 50 characters")]
        [MinLength(3, ErrorMessage = "You need to enter at least 3 characters for the name of the Care Home")]
        [DisplayName("Name of the Care Home")]
        public string careHome { get; set; }

        [Required]
        [DisplayName("CareHome Description")]
        public string careHomeDescription { get; set; }

    }
}
