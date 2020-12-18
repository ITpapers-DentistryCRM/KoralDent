using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.BLL.Models
{
    [Serializable]
    public class ServiceDTO
    {

        public int ServiceId { get; set; }

        [Required]
        [StringLength(50)]
        public string ServiceName { get; set; }

        [Required]
        [StringLength(200)]
        public string ServiceDescription { get; set; }

        public TimeSpan ServiceDuration { get; set; }

        public double ServicePrice { get; set; }

        public int SpecializationId { get; set; }
        public string SpecializationName { get; set; }

    }

}
