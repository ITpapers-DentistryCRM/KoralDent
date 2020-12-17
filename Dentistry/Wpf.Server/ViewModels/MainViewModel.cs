using Autofac;
using Clinic.BLL.Services;
using Clinic.BLL.Models;
using Clinic.BLL.Infrastructure;
using Clinic.Sheduler.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using Wpf.Server.Infrastructure;
using Wpf.Server.Infrastructure.DialogService;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Wpf.Server.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        IDialogService dialogService;


        TcpListener listener;

        private string _txtIPAddress;

        public string TxtIPAddress
        {
            get { return _txtIPAddress; }
            set { _txtIPAddress = value;
                OnPropertyChanged(); }
        }
        private string _txtPort;
        public string TxtPort
        {
            get { return _txtPort; }
            set
            {
                _txtPort = value;
                OnPropertyChanged();
            }
        }
        private string _logs;
        public string Logs
        {
            get { return _logs; }
            set
            {
                _logs = value;
                OnPropertyChanged();
            }
        }

        private string _currentTime = $"{new string(' ',20)}";

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


        private bool _isServerWork;
        public bool isServerShut {
            get { return _isServerWork; } 
            set {
                _isServerWork = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            isServerShut = true;
            TxtIPAddress = ConfigurationManager.AppSettings["IPAddress"];
            TxtPort = ConfigurationManager.AppSettings["Port"];


            _timer = new DispatcherTimer(DispatcherPriority.Render);
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (sender, args) =>
            {
                CurrentTime = DateTime.Now.ToLongTimeString();
            };
            _timer.Start();



        }
        static Autofac.IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<RegisterModule>();
            return builder.Build();
        }
        private async Task<List<Appointment>> GetAppointments()
        {
            
            Autofac.IContainer container = BuildContainer();

            IGenericService<RegistrationDTO, int> registrations = container.Resolve<IGenericService<RegistrationDTO, int>>();
            var collection = registrations.GetAll();
            IGenericService<Registration_ServiceDTO, int> registration_services = container.Resolve<IGenericService<Registration_ServiceDTO, int>>();
            var registration_services_collection = registration_services.GetAll();
            IGenericService<ServiceDTO, int> services = container.Resolve<IGenericService<ServiceDTO, int>>();
            IGenericService<PatientDTO, int> patients = container.Resolve<IGenericService<PatientDTO, int>>();
            IGenericService<DoctorDTO, int> doctors = container.Resolve<IGenericService<DoctorDTO, int>>();

            return await Task<List<Appointment>>.Factory.StartNew(() => {
                List<Appointment> appointments = new List<Appointment>();
                foreach (var item in collection)
                {
                    DateTime start = new DateTime(item.RegistrationDate.Year, item.RegistrationDate.Month, item.RegistrationDate.Day, item.RegistrationTime.Hours, item.RegistrationTime.Minutes, item.RegistrationTime.Seconds);
                    TimeSpan timeSpan = new TimeSpan();
                    PatientDTO patient = patients.Get(item.PatientId);
                    DoctorDTO doctor = doctors.Get(item.DoctorId);
                    string sers = "Services:\n";
                    double totalPrice = 0;
                    foreach (var rs in registration_services_collection)
                    {
                        if(rs.RegistrationId == item.RegistrationId)
                        {
                            ServiceDTO service = services.Get(rs.ServiceId);
                            timeSpan += service.ServiceDuration;
                            sers += $"{service.ServiceName}  -> ${service.ServicePrice}\n";
                            totalPrice += service.ServicePrice;
                        }
                        
                    }
                    string descr = $"Doctor: {doctor.StaffLastName} {doctor.StaffName} {doctor.StaffMiddleName}\n\n" +
                                     $"Patient: {patient.PatientName} {patient.PatientPhone} {patient.PatientEmail}\n\n" +
                                     $"{sers}\n\n" +
                                     $"Total Price: {totalPrice}\n\n" +
                                     $"Comment: {item.RegistrationComment}";
                    appointments.Add(new Appointment()
                    {
                        Id = item.RegistrationId,
                        Start = start,
                        End = start.AddMinutes(timeSpan.TotalMinutes),
                        Subject = $"{doctor.StaffLastName} - {patient.PatientName}",
                        Description = descr,
                        AppointmentType = 0,
                        Label =6,
                        RecurrenceInfo = "",
                        ResourceId=0
                    });

                }
                return appointments;
            });
            
        }

        RelayCommand _runServerCommand;

        public ICommand RunServer_Click
        {
            get
            {
                if (_runServerCommand == null)
                    _runServerCommand = new RelayCommand(ExecuteRunServerCommand, o => isServerShut == true);
                return _runServerCommand;
            }
        }
        private async void ExecuteRunServerCommand(object parameter)
        {
            List<Appointment> appoinments = null;
            
            try
            {
                Logs += $"{DateTime.Now,-15} - Server starting...\n";
                IPAddress localaddr = IPAddress.Parse(TxtIPAddress);
                int port = Convert.ToInt32(TxtPort);
                listener = new TcpListener(localaddr, port);
                listener.Start();
                isServerShut = false;
            }
            catch (Exception)
            {
                dialogService.MessageBoxOkError("ERROR: Cannot start server (wrong parameters)", "SERVER ERROR!");
                return;
            }



            try
            {
                Logs += $"{DateTime.Now,-15} - Server started without errors.\n";
                Logs += $"{DateTime.Now,-15} - Server listening...\n";
                byte[] data;
                appoinments = await GetAppointments();
                while (isServerShut == false)
                {
                    //TcpClient cl = listener.AcceptTcpClientAsync();
                    var client = await listener.AcceptTcpClientAsync();
                    Logs += $"{DateTime.Now,-15} - Server accept ADMINISTRATOR - {client.Client.RemoteEndPoint}\n";
                    var binFormatter = new BinaryFormatter();
                    var mStream = new MemoryStream();
                    binFormatter.Serialize(mStream, appoinments);

                    //This gives you the byte array.
                    data = mStream.ToArray();

                    NetworkStream stream = client.GetStream();
                    //StringBuilder builder = new StringBuilder();
                    //int bytes = 0;
                    //do
                    //{
                    //    bytes = await stream.ReadAsync(data, 0, data.Length);
                    //    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    //}
                    //while (stream.DataAvailable);
                    //lbMessage.Items.Add($"from client {client.Client.RemoteEndPoint} - message {builder.ToString()}");
                    //dialogService.MessageBoxYesNo(data.Length.ToString());
                    //var data1 = Encoding.Unicode.GetBytes(builder.ToString().ToUpper());
                    Logs += $"{DateTime.Now,-15} - Server writing to ADMINISTRATOR - {client.Client.RemoteEndPoint}\n";
                    await stream.WriteAsync(data, 0, data.Length);
                    Logs += $"{DateTime.Now,-15} - Server close connection with ADMINISTRATOR - {client.Client.RemoteEndPoint}\n";


                }
            }
            catch (Exception exc)
            {
                if(isServerShut)
                {
                    Logs += $"{DateTime.Now,-15} - Server finished without errors.\n";
                }
                else
                {
                    dialogService.MessageBoxOkError(exc.Message, "SERVER ERROR!");
                    Logs += $"{DateTime.Now,-15} - Server finished with ERROR: {exc.Message}\n";
                }
                

            }
        }


        RelayCommand _stopServerCommand;

        public ICommand StopServer_Click
        {
            get
            {
                if (_stopServerCommand == null)
                    _stopServerCommand = new RelayCommand(ExecuteStopServerCommand, o => isServerShut == false);
                return _stopServerCommand;
            }
        }
        private void ExecuteStopServerCommand(object parameter)
        {
            if(dialogService.MessageBoxYesNo("Do you really want to close server?","Server closing...") == DialogResult.Yes)
            {
                isServerShut = true;
                listener.Stop();
            }
            
        }
    }
}
