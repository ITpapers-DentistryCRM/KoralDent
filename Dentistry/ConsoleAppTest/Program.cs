using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Clinic.BLL.Services;
using Clinic.BLL.Models;
using Clinic.BLL.Infrastructure;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using Clinic.Sheduler.Models;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleAppTest
{
    class Program
    {
        static TcpClient client;
        static NetworkStream stream;
        static BinaryReader reader;
        static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<RegisterModule>();
            return builder.Build();
        }
        public static void ReceiveMessage()
        {
            TcpClient tcpClient = new TcpClient("127.0.0.1", 9900);

            NetworkStream networkStream = tcpClient.GetStream();

            List<Appointment> appointments;
            //while (true)
            {
                try
                {

                        var binFormatter = new BinaryFormatter();

                        appointments = binFormatter.Deserialize(networkStream) as List<Appointment>;

                        foreach (var item in appointments)
                        {
                            Console.WriteLine(item.Description);
                        }
                 }
                catch (Exception exc)
                {

                    string s = exc.Message;
                    //Console.WriteLine("Подключение прервано!"); //соединение было прервано
                    //Console.ReadLine();
                    //Disconnect();
                }
            }
        }
        static void Main(string[] args)
        {
            Console.ReadKey();
            //client = new TcpClient();
            //client.Connect("127.0.0.1", 9900);

            //stream = client.GetStream();
            ReceiveMessage();

            //Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
            //receiveThread.IsBackground = true;
            //receiveThread.Start();

            Console.ReadKey();




            //IContainer container = BuildContainer();

            //IGenericService<ServiceDTO, int> service = container.Resolve<IGenericService<ServiceDTO, int>>();
            //var collection = service.GetAll();
            //foreach (var item in collection)
            //{
            //    Console.WriteLine(item.SpecializationName);
            //}

            //Console.WriteLine("-----------------------\n\n");
            //IGenericService<StaffDTO, int> serviceStaff = container.Resolve<IGenericService<StaffDTO, int>>();
            //ObservableCollection<StaffDTO> producers = new ObservableCollection<StaffDTO>(serviceStaff.GetAll());
            //foreach (var item in producers)
            //{
            //    Console.WriteLine(item.StaffLastName);
            //}
            //Console.WriteLine("-----------------------\n\n");

            //IGenericService<DoctorDTO, int> doctors = container.Resolve<IGenericService<DoctorDTO, int>>();
            //var gg = doctors.GetAll();

            //foreach (var item in gg)
            //{
            //    Console.WriteLine($"{item.SpecializationName,-40} {item.StaffLastName} {item.AccountLevel} {item.AccountPassword} {item.StaffSalary}");
            //}
            //Console.WriteLine("-----------------------\n\n");

            //IGenericService<RegistrationDTO, int> regists = container.Resolve<IGenericService<RegistrationDTO, int>>();
            //var goods = regists.GetAll();

            //foreach (var item in goods)
            //{
            //    Console.WriteLine($"{doctors.Get(item.DoctorId).StaffLastName,-40} {item.PatientId}");
            //}

        }
    }
}
