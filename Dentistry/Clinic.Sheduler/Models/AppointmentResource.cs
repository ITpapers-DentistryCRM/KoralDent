using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Sheduler.Models
{
    [Serializable]
    public class AppointmentResource
    {
        public List<Appointment> Appointments { get; set; }
        public List<Resource> Resources { get; set; }
    }
}
