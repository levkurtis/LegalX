using System;

namespace LegalX
{
    public class Processor
    {
        public void Process()
        {
            Login();
        }
        public void Login()
        {
            Console.WriteLine(@"
Welcome to the LegalX system
Please pick who your occupation:
1. Lawyer
2. Administration
3. Receptionist
");

            int userOccupation = int.Parse(Console.ReadLine());
            while (userOccupation < 1 || userOccupation > 3)
            {
                Console.WriteLine("Invalid key pressed, please try again");
                userOccupation = int.Parse(Console.ReadLine());
            }

            //login authentication, main menu + login info depend on user picked
            Console.WriteLine("Please provide username to access the LegalX system");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Please provide password");
            Console.Write("Password: ");
            string password = Console.ReadLine();
            LegalXEmployee u;
            switch (userOccupation)
            {
                case 1:
                    //For senior: username = senlaw, password = password
                    //For junior: username = junlaw, password = password
                    if (username == "senlaw" && password == "password") //senior login
                    {
                        u = new SeniorLawyer(0, "Senior Lawyer", "lawyer", DateTime.ParseExact("01-01-1950", "dd-MM-yyyy", null), DateTime.ParseExact("01-01-1950", "dd-MM-yyyy", null), ESeniority.Senior, ESpecialization.Unknown, ESpecialization.Unknown);
                        Console.WriteLine($"\nWelcome {u.FirstName}");
                        u.ObjectsInit();
                        u.ShowMenuOptions();
                    }
                    else if (username == "junlaw" && password == "password") //junior login
                    {
                        u = new JuniorLawyer(0, "Junior Lawyer", "lawyer", DateTime.ParseExact("01-01-1950", "dd-MM-yyyy", null), DateTime.ParseExact("01-01-1950", "dd-MM-yyyy", null), ESeniority.Junior, ESpecialization.Unknown, ESpecialization.Unknown);
                        Console.WriteLine($"\nWelcome {u.FirstName}");
                        u.ObjectsInit();
                        u.ShowMenuOptions();
                    }
                    else
                    {
                        Console.WriteLine("You are not authorized to access this service");
                    }
                    break;

                case 2:
                    //username = adminstaff, password = password
                    if (username == "adminstaff" && password == "password") //Admin staff login
                    {
                        u = new AdminStaff(0, "Admin Staff", "staff", DateTime.ParseExact("01-01-1950", "dd-MM-yyyy", null), "n/a");

                        Console.WriteLine($"\nWelcome {u.FirstName}");
                        u.ObjectsInit();
                        u.ShowMenuOptions();
                    }
                    else
                    {
                        Console.WriteLine("You are not authorized to access this service");
                    }
                    break;

                case 3:
                    //username = adminrecept, password = password
                    if (username == "recept" && password == "password") //Reception login
                    {
                        u = new Receptionist(0, "Receptionist", "recept", DateTime.ParseExact("01-01-1950", "dd-MM-yyyy", null));
                        Console.WriteLine($"\nWelcome {u.FirstName}");
                        u.ObjectsInit();
                        u.ShowMenuOptions();
                    }
                    else
                    {
                        Console.WriteLine("You are not authorized to access this service");
                    }
                    break;
                default:
                    Console.WriteLine("Something went wrong");
                    break;
            }
        }
    }
}
