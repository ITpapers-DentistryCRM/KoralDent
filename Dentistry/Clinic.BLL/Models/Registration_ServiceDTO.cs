using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.BLL.Models
{

    public class Registration_ServiceDTO
    {
        public int Registration_ServiceId { get; set; }

        public int RegistrationId { get; set; }
        public RegistrationDTO Registration { get; set; }

        public int ServiceId { get; set; }
        public ServiceDTO Service { get; set; }

    }
}
