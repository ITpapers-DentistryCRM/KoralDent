using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Threading;
using Wpf.Administrator.Infrastructure.DialogService;
using DevExpress.Xpf.Core;
using System.Windows;
using System.Net.Sockets;
using Clinic.Sheduler.Models;
using System.Runtime.Serialization.Formatters.Binary;

namespace Wpf.Administrator.ViewModels
{
    class AdministratorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        IDialogService dialogService;

        private string _currentTime = $"{new string(' ', 20)}";

        public DispatcherTimer _timer;

        public string CurrentTime
        {
            get
            {
                return this._currentTime;
            }
            set
            {
                if (_currentTime == value)
                    return;
                _currentTime = value;
                OnPropertyChanged();
            }
        }

        public string IPAddress { get; set; }
        public int Port { get; set; }

        private List<Appointment> _appointments;

        public List<Appointment> Appointments
        {
            get { return _appointments; }
            set { _appointments = value;
                OnPropertyChanged();
            }
        }
        private List<Resource> _calendars;

        public List<Resource> Calendars
        {
            get { return _calendars; }
            set
            {
                _calendars = value;
                OnPropertyChanged();
            }
        }
        public void About_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            DXMessageBox.Show(@"This example demonstrates how to customize the WPF Scheduler's integrated ribbon UI. Use the Scheduler's RibbonActions collection to create, remove or modify ribbon elements.",
                "Scheduler Ribbon Example", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        public AdministratorViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            Calendars = new List<Resource>();
            Calendars.Add(new Resource() { Id = 0, Description = "Appoinment" });

            IPAddress = ConfigurationManager.AppSettings["IPAddress"];
            Port = int.Parse(ConfigurationManager.AppSettings["Port"]);

            TcpClient tcpClient = new TcpClient(IPAddress, Port);

            NetworkStream networkStream = tcpClient.GetStream();

            var binFormatter = new BinaryFormatter();

            Appointments = binFormatter.Deserialize(networkStream) as List<Appointment>;

            foreach (var item in Appointments)
            {
               // dialogService.MessageBoxYesNo(item.Description);
            }

            _timer = new DispatcherTimer(DispatcherPriority.Render);
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (sender, args) =>
            {
                CurrentTime = DateTime.Now.ToLongTimeString();
            };
            _timer.Start();



        }
    }
}
