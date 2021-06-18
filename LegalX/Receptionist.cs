using System;

namespace LegalX
{
    public class Receptionist : LegalXEmployee, IGeneralProperties, IEmployeeProperties
    {
        //Constructor
        public Receptionist(int id, string firstName, string lastName, DateTime joinedOn) : base(id, firstName, lastName, joinedOn)
        {

        }

        //Methods
        public void AddNewClient()
        {
            Console.WriteLine("\nPlease input");
            int id = UniqueId();
            Console.Write("First name: ");
            string firstName = Console.ReadLine();
            Console.Write("Middle name: ");
            string middleName = Console.ReadLine();
            Console.Write("Last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Please enter Date of Birth (dd-MM-yyyy)");
            DateTime dob = ValidDateCheck();

            Console.Write("Street: ");
            string street = Console.ReadLine();
            Console.Write("Street Nr.: ");
            string streetNr = Console.ReadLine();
            Console.Write("Zip: ");
            string zip = Console.ReadLine();
            Console.Write("City: ");
            string city = Console.ReadLine();

            Client clientAdd = new Client(id, firstName, middleName, lastName, dob, street, streetNr, zip, city);
            Clients.Add(clientAdd);
            Console.WriteLine("Client added");

        }


        public void AddNewAppointment()
        {
            Console.WriteLine("\nPlease input");
            int id = UniqueId();
            Console.Write("Client Id: ");
            int clientId = int.Parse(Console.ReadLine());
            Console.Write("Lawyer Id: ");
            int lawyerId = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter date for future appointment (dd-MM-yyyy)");//h:mm AM/PM

            DateTime dateTime = ValidDateCheck();
            dateTime = HourMinuteInput(dateTime);

            Console.WriteLine("Which meeting room is the appointment?");
            Console.WriteLine("Warrior = 1, SOS = 2, Cube = 3, Cave = 4, if unknown press enter any other key");

            string inputMeetingRoom = Console.ReadLine();
            EMeetingRoom meetingRoom;
            switch (inputMeetingRoom)
            {
                case "1":
                    meetingRoom = EMeetingRoom.Warrior;
                    break;
                case "2":
                    meetingRoom = EMeetingRoom.SOS;
                    break;
                case "3":
                    meetingRoom = EMeetingRoom.Cube;
                    break;
                case "4":
                    meetingRoom = EMeetingRoom.Cave;
                    break;
                default:
                    meetingRoom = EMeetingRoom.Unknown;
                    break;
            }
            Console.Write("Short Description: ");
            string shortDescription = Console.ReadLine();

            Appointment appointmentAdd = new Appointment(id, clientId, lawyerId, dateTime, meetingRoom, shortDescription);
            Appointments.Add(appointmentAdd);
            Console.WriteLine("Client added");
        }


        DateTime HourMinuteInput(DateTime dateTime) //Used to specify time for appointements
        {
            Console.WriteLine("Please enter time for the appointment: (hour [h])\nBetween 0 - 12"); //hour
            int inputHourOfDay = int.Parse(Console.ReadLine());
            while (inputHourOfDay < 0 || inputHourOfDay > 12)
            {
                Console.WriteLine("Invalid value inputed, please try again");
                inputHourOfDay = int.Parse(Console.ReadLine());
            }
            dateTime = dateTime.AddHours(inputHourOfDay);


            Console.WriteLine("Please enter time for the appointment: (minutes [mm])\nBetween 0 - 59"); //minutes
            int inputMinuteOfDay = int.Parse(Console.ReadLine());
            while (inputMinuteOfDay < 0 || inputMinuteOfDay > 59)
            {
                Console.WriteLine("Invalid value inputed, please try again");
                inputMinuteOfDay = int.Parse(Console.ReadLine());
            }
            dateTime = dateTime.AddMinutes(inputMinuteOfDay);

            Console.WriteLine("Please select: 1. AM or 2. PM?");
            int inputAMPM = int.Parse(Console.ReadLine());
            while (inputAMPM < 1 || inputAMPM > 2)
            {
                Console.WriteLine("Invalid value inputed, please try again");
                inputAMPM = int.Parse(Console.ReadLine());
            }
            if (inputAMPM == 2) //Adds 12 hours to time, makes it PM
                dateTime = dateTime.AddHours(12);
            return dateTime;
        }


        public override void ShowMenuOptions()
        {
            string input = "";
            while (input != "0")
            {
                //Receptionist menu
                Console.WriteLine(@"
****** Here are your options ******
Please select the action
1. Register a new client
2. Add a new appointment
3. View all appointments
4. View all clients
0. To exit program
");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        try
                        {
                            AddNewClient();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("\nAn error occured");
                            Console.WriteLine($"Error message: {ex.Message}");
                            Console.WriteLine("\nReturning to main menu...\n");
                        }
                        break;
                    case "2":
                        try
                        {
                            AddNewAppointment();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("\nAn error occured");
                            Console.WriteLine($"Error message: {ex.Message}");
                            Console.WriteLine("\nReturning to main menu...\n");
                        }
                        break;
                    case "3":
                        ListAppointments();
                        break;
                    case "4":
                        ListClients();
                        break;
                    case "0":
                        //quit
                        Console.WriteLine("\nExiting program...");
                        break;
                    default:
                        Console.WriteLine("\nInvalid key entered");
                        break;
                }

            }
        }
    }
}