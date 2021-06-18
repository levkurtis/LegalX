using System;
namespace LegalX
{
    public abstract class Lawyer : LegalXEmployee, IGeneralProperties, IEmployeeProperties
    {
        //Properties
        DateTime dob;

        DateTime DOB //Lawyers can max be 100 years old
        {
            get { return dob; }
            set
            {
                if (value < DateTime.Now && value > DateTime.Now.AddYears(-100))
                {
                    dob = value;
                }
                else
                {
                    throw new Exception("Invalid date of birth entered\nLawyer is minimum born today and cannot be more than 100 years old\nContact admin if problem persists");
                }
            }
        }
        ESeniority Seniority { get; set; } //Junior or Senior
        ESpecialization Specialization { get; set; } //Corporate, FamilyCase or CriminalCase
        ESpecialization ExpertiseDomain { get; set; } //Corporate, FamilyCase or CriminalCase


        //Constructor
        public Lawyer(int id, string firstName, string lastName, DateTime joinedOn, DateTime dob, ESeniority seniority, ESpecialization specialization, ESpecialization expertiseDomain) : base(id, firstName, lastName, joinedOn)
        {
            DOB = dob;
            Seniority = seniority;
            Specialization = specialization;
            ExpertiseDomain = expertiseDomain;
        }


        //Methods
        public void AddNewCase()
        {
            //lawyer instantiate case object + put into case list
            Console.WriteLine("\nPlease input");
            int id = UniqueId();
            Console.Write("Customer Id: ");
            int customerId = int.Parse(Console.ReadLine());
            Console.WriteLine("What type of case is it?");
            Console.WriteLine("Corporate = 1, Family = 2, Criminal = 3, if unknown press enter any other key:");
            string inputCaseType = Console.ReadLine();
            ECaseType caseType;
            switch (inputCaseType)
            {
                case "1":
                    caseType = ECaseType.Corporate;
                    break;
                case "2":
                    caseType = ECaseType.Family;
                    break;
                case "3":
                    caseType = ECaseType.Criminal;
                    break;
                default:
                    caseType = ECaseType.Unknown;
                    break;
            }

            Console.WriteLine("Please enter future date for case (dd-MM-yyyy):");
            DateTime startDate = ValidDateCheck();

            Console.Write("Total charge: ");
            int totalCharge = int.Parse(Console.ReadLine());
            Console.Write("Lawyer Id: ");
            int lawyerId = int.Parse(Console.ReadLine());
            Console.Write("Case description: ");
            string caseDescription = Console.ReadLine();
            Console.Write("Notes: ");
            string notes = Console.ReadLine();

            Case caseAdd = new Case(id, customerId, caseType, startDate, totalCharge, lawyerId, caseDescription, notes);
            Cases.Add(caseAdd);
            Console.WriteLine("Case added");
        }


        public override void ShowMenuOptions()
        {
            string input = "";
            while (input != "0")
            {
                //Lawyer menu
                Console.WriteLine(@"
****** Here are your options ******
Please select the action
1. View all cases
2. View all appointments
3. Add a new case
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
                    case "3":
                        try
                        {
                            AddNewCase();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("\nAn error occured");
                            Console.WriteLine($"Error message: {ex.Message}");
                            Console.WriteLine("\nReturning to main menu...\n");
                        }
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


    //Enumerators
    public enum ESpecialization
    {
        Unknown = 0, Corporate = 1, FamilyCase = 2, CriminalCase = 3
    }

    public enum ESeniority
    {
        Unknown = 0, Junior = 1, Senior = 2
    }
}