using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.BLL.Models
{

    public class RegistrationStatusDTO
    {

        public int RegistrationStatusId { get; set; }

        [Required]
        [StringLength(30)]
        public string RegistrationStatusName { get; set; }

        [Required]
        [StringLength(300)]
        public string RegistrationStatusInfo { get; set; }

    }
}
