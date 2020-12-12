using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.BLL.Models
{

    public class StaffDTO
    {
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

        [Column(TypeName = "date")]
        public DateTime StaffBirthday { get; set; }

        public double StaffSalary { get; set; }

    }
}
