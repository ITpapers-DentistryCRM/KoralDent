using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.BLL.Models
{

    public class PatientDTO
    {

        public int PatientId { get; set; }

        [Required]
        [StringLength(50)]
        public string PatientName { get; set; }

        [Required]
        [StringLength(50)]
        public string PatientPhone { get; set; }

        [Required]
        [StringLength(50)]
        public string PatientEmail { get; set; }

    }
}
