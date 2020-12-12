using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.BLL.Models
{

    public class SpecializationDTO
    {
        public int SpecializationId { get; set; }

        [Required]
        [StringLength(50)]
        public string SpecializationName { get; set; }

    }
}
