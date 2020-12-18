using Clinic.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Sheduler.Models
{
    [Serializable]
    public class Appointment
    {
        public Appointment()
        {

        }
        public int Id { get; set; }
        public string Subject { get; set; }
        //Comment
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int AppointmentType { get; set; }
        public string RecurrenceInfo { get; set; }
        //Doctor
        public int ResourceId { get; set; }
        public int Label { get; set; }

        //Custom properties:
        public string PatientName { get; set; }
        public string PatientPhone { get; set; }
        public string PatientEmail { get; set; }

        private List<ServiceDTO> _services;

        public List<ServiceDTO> Services
        {
            get { return _services; }
            set { _services = value; }
        }

    }
    
}
