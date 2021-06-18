using System;
namespace LegalX
{
    public class AdminStaff : LegalXEmployee, IGeneralProperties, IEmployeeProperties
    {
        //Properties
        string Role { get; set; }

        //Constructor
        public AdminStaff(int id, string firstName, string lastName, DateTime joinedOn, string role) : base(id, firstName, lastName, joinedOn)
        {
            Role = role;
        }

        //Methods
        public override void ShowMenuOptions()
        {
            string input = "";
            while (input != "0")
            {
                //Admin Staff Menu
                Console.WriteLine(@"
****** Here are your options ******
Please select the action
1. View all clients
2. View list of all appointments
0. To exit program
");

                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ListCases();
                        break;
                    case "2":
                        ListAppointments();
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
