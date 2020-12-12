using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.BLL.Models
{

    public class DoctorDTO
    {

        public int DoctorId { get; set; }

        public int SpecializationId { get; set; }
        public string SpecializationName { get; set; }

        public int StaffId { get; set; }
        public StaffDTO Staff { get; set; }

        [Required]
        [StringLength(500)]
        public string DoctorInfo { get; set; }

    }
}
