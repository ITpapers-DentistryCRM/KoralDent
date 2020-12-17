using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.BLL.Models
{

    public class RegistrationDTO
    {

        public int RegistrationId { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; set; }

        public TimeSpan RegistrationTime { get; set; }

        [StringLength(300)]
        public string RegistrationComment { get; set; }

        public int DoctorId { get; set; }
        //public DoctorDTO Doctor { get; set; }

        public int PatientId { get; set; }
        //public PatientDTO Patient { get; set; }

        public int RegistrationStatusId { get; set; }
        public string RegistrationStatusName { get; set; }
        public string RegistrationStatusInfo { get; set; }

    }
}
