
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

        [Required]
        [StringLength(500)]
        public string DoctorInfo { get; set; }

        public int StaffId { get; set; }

        public int AccountId { get; set; }
        public string AccountLogin { get; set; }
        public string AccountPassword { get; set; }
        //0-NULL; 1-SomeStaff; 2-Doctor; 3-Administartor; 4-Boss
        public int AccountLevel { get; set; }

        [Required]
        [StringLength(50)]
        public string StaffLastName { get; set; }

        [Required]
        [StringLength(50)]
        public string StaffName { get; set; }

        [Required]
        [StringLength(50)]
        public string StaffMiddleName { get; set; }

        public DateTime StaffBirthday { get; set; }

        public double StaffSalary { get; set; }

    }
}
