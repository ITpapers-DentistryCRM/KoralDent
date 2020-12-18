using DevExpress.Xpf.Scheduling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Administrator.ViewModels
{

    public class AppointmentViewModel : AppointmentWindowViewModel
    {
        public AppointmentViewModel(AppointmentItem appointmentItem, SchedulerControl scheduler) : base(appointmentItem, scheduler) { MyProperty = "KEK"; }
        //...
        private void Scheduler_AppointmentWindowShowing(object sender, DevExpress.Xpf.Scheduling.AppointmentWindowShowingEventArgs e)
        {
            e.Window.DataContext = new AppointmentViewModel(e.Appointment, (SchedulerControl)sender);
        }

        public string MyProperty { get; set; }
    }
}
