using System;
using System.Collections.Generic;

namespace LegalX
{
    public abstract class LegalXEmployee : IGeneralProperties, IEmployeeProperties
    {
        //Lists
        public List<Appointment> Appointments = new List<Appointment>();
        public List<Client> Clients = new List<Client>();
        public List<Case> Cases = new List<Case>();
        public List<LegalXEmployee> Employees = new List<LegalXEmployee>();

        //Properties
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinedOn { get; set; }


        //Constructor
        public LegalXEmployee(int id, string firstName, string lastName, DateTime joinedOn)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            JoinedOn = joinedOn;
        }

        //Methods
        public void ListCases() //Available for Receptionist and Lawyers
        {
            Console.WriteLine($"List of info for all cases\nTotal: {Cases.Count} cases\n**********");
            foreach (Case c in Cases)
            {
                Console.WriteLine(c.GenerateDescription());
            }
        }

        public void ListAppointments() //Available for Receptionist, Admin staff and Lawyers
        {
            Console.WriteLine($"List of info for all appointments\nTotal: {Appointments.Count} appointments\n**********");
            foreach (Appointment a in Appointments)
            {
                Console.WriteLine(a.GenerateDescription());
            }
        }

        public void ListClients() //Available for Receptionist and Admin staff
        {
            Console.WriteLine($"List of info for all clients\nTotal: {Clients.Count} clients\n**********");
            foreach (Client cli in Clients)
            {
                Console.WriteLine(cli.GenerateDescription());
            }
        }

        public int UniqueId() //returns unique id to objects in database, based on total objects
        {
            int id = Employees.Count + Cases.Count + Clients.Count + Appointments.Count;
            return id + 1;
        }

        public DateTime ValidDateCheck() //checks whether date inputted is valid
        {
            DateTime dateInput = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);
            return dateInput;
        }


        public abstract void ShowMenuOptions();


        //Method for initializing objects
        public void ObjectsInit()
        {
            //Senior Lawyer Init
            LegalXEmployee s1 = new SeniorLawyer(1, "Bill", "Gates", DateTime.ParseExact("11-06-1992", "dd-MM-yyyy", null), DateTime.ParseExact("09-08-1975", "dd-MM-yyyy", null), ESeniority.Senior, ESpecialization.CriminalCase, ESpecialization.CriminalCase); //the specialization could be enum instead 
            LegalXEmployee s2 = new SeniorLawyer(2, "Steve", "Jobs", DateTime.ParseExact("21-01-1987", "dd-MM-yyyy", null), DateTime.ParseExact("21-12-1978", "dd-MM-yyyy", null), ESeniority.Senior, ESpecialization.Corporate, ESpecialization.Corporate);
            LegalXEmployee s3 = new SeniorLawyer(3, "Eren", "Jaeger", DateTime.ParseExact("16-11-1989", "dd-MM-yyyy", null), DateTime.ParseExact("29-04-1971", "dd-MM-yyyy", null), ESeniority.Senior, ESpecialization.CriminalCase, ESpecialization.CriminalCase);
            LegalXEmployee s4 = new SeniorLawyer(4, "Brad", "Pitt", DateTime.ParseExact("24-04-1990", "dd-MM-yyyy", null), DateTime.ParseExact("21-01-1965", "dd-MM-yyyy", null), ESeniority.Senior, ESpecialization.Corporate, ESpecialization.Corporate);
            LegalXEmployee s5 = new SeniorLawyer(5, "Ryan", "Gosling", DateTime.ParseExact("13-12-1992", "dd-MM-yyyy", null), DateTime.ParseExact("21-08-1969", "dd-MM-yyyy", null), ESeniority.Senior, ESpecialization.CriminalCase, ESpecialization.CriminalCase);
            LegalXEmployee s6 = new SeniorLawyer(6, "Light", "Yagami", DateTime.ParseExact("30-06-1991", "dd-MM-yyyy", null), DateTime.ParseExact("02-06-1967", "dd-MM-yyyy", null), ESeniority.Senior, ESpecialization.FamilyCase, ESpecialization.FamilyCase);
            LegalXEmployee s7 = new SeniorLawyer(7, "Scarlett", "Johansson", DateTime.ParseExact("16-07-1987", "dd-MM-yyyy", null), DateTime.ParseExact("21-11-1973", "dd-MM-yyyy", null), ESeniority.Senior, ESpecialization.FamilyCase, ESpecialization.FamilyCase);

            Employees.Add(s1);
            Employees.Add(s2);
            Employees.Add(s3);
            Employees.Add(s4);
            Employees.Add(s5);
            Employees.Add(s6);
            Employees.Add(s7);


            //Junior Lawyer Init
            LegalXEmployee j1 = new JuniorLawyer(8, "Tanjiro", "Kamado", DateTime.ParseExact("16-09-2000", "dd-MM-yyyy", null), DateTime.ParseExact("11-07-1988", "dd-MM-yyyy", null), ESeniority.Junior, ESpecialization.Corporate, ESpecialization.Corporate);
            LegalXEmployee j2 = new JuniorLawyer(9, "Nezuko", "Kamado", DateTime.ParseExact("18-06-2001", "dd-MM-yyyy", null), DateTime.ParseExact("11-08-1988", "dd-MM-yyyy", null), ESeniority.Junior, ESpecialization.CriminalCase, ESpecialization.CriminalCase);
            LegalXEmployee j3 = new JuniorLawyer(10, "Arataka", "Reigen", DateTime.ParseExact("16-03-1993", "dd-MM-yyyy", null), DateTime.ParseExact("07-11-1988", "dd-MM-yyyy", null), ESeniority.Junior, ESpecialization.Corporate, ESpecialization.Corporate);
            LegalXEmployee j4 = new JuniorLawyer(11, "Eikichi", "Onizuka", DateTime.ParseExact("01-09-2006", "dd-MM-yyyy", null), DateTime.ParseExact("04-01-1987", "dd-MM-yyyy", null), ESeniority.Junior, ESpecialization.FamilyCase, ESpecialization.FamilyCase);
            LegalXEmployee j5 = new JuniorLawyer(12, "Gordon", "Ramsay", DateTime.ParseExact("19-03-1993", "dd-MM-yyyy", null), DateTime.ParseExact("07-01-1985", "dd-MM-yyyy", null), ESeniority.Junior, ESpecialization.FamilyCase, ESpecialization.FamilyCase);
            LegalXEmployee j6 = new JuniorLawyer(13, "Halle", "Berry", DateTime.ParseExact("21-09-2012", "dd-MM-yyyy", null), DateTime.ParseExact("02-11-1994", "dd-MM-yyyy", null), ESeniority.Junior, ESpecialization.Corporate, ESpecialization.Corporate);
            LegalXEmployee j7 = new JuniorLawyer(14, "Kanye", "West", DateTime.ParseExact("16-10-2006", "dd-MM-yyyy", null), DateTime.ParseExact("17-07-1998", "dd-MM-yyyy", null), ESeniority.Junior, ESpecialization.Corporate, ESpecialization.Corporate);
            LegalXEmployee j8 = new JuniorLawyer(15, "Kobe", "Bryant", DateTime.ParseExact("14-01-1993", "dd-MM-yyyy", null), DateTime.ParseExact("01-10-1988", "dd-MM-yyyy", null), ESeniority.Junior, ESpecialization.Corporate, ESpecialization.Corporate);
            LegalXEmployee j9 = new JuniorLawyer(16, "LeBron", "James", DateTime.ParseExact("27-12-2010", "dd-MM-yyyy", null), DateTime.ParseExact("04-01-1990", "dd-MM-yyyy", null), ESeniority.Junior, ESpecialization.CriminalCase, ESpecialization.CriminalCase);
            LegalXEmployee j10 = new JuniorLawyer(17, "Mila", "Kunis", DateTime.ParseExact("19-08-2016", "dd-MM-yyyy", null), DateTime.ParseExact("21-07-1989", "dd-MM-yyyy", null), ESeniority.Junior, ESpecialization.FamilyCase, ESpecialization.FamilyCase);
            LegalXEmployee j11 = new JuniorLawyer(18, "Naomi", "Osaka", DateTime.ParseExact("16-01-2011", "dd-MM-yyyy", null), DateTime.ParseExact("29-01-1994", "dd-MM-yyyy", null), ESeniority.Junior, ESpecialization.FamilyCase, ESpecialization.FamilyCase);
            LegalXEmployee j12 = new JuniorLawyer(19, "Chihiro", "Ogino", DateTime.ParseExact("06-01-2015", "dd-MM-yyyy", null), DateTime.ParseExact("17-01-1988", "dd-MM-yyyy", null), ESeniority.Junior, ESpecialization.FamilyCase, ESpecialization.FamilyCase);
            LegalXEmployee j13 = new JuniorLawyer(20, "Stephanie", "Allen", DateTime.ParseExact("16-01-2016", "dd-MM-yyyy", null), DateTime.ParseExact("11-02-1989", "dd-MM-yyyy", null), ESeniority.Junior, ESpecialization.CriminalCase, ESpecialization.CriminalCase);
            LegalXEmployee j14 = new JuniorLawyer(21, "Mikasa", "Ackerman", DateTime.ParseExact("13-11-2004", "dd-MM-yyyy", null), DateTime.ParseExact("07-01-1998", "dd-MM-yyyy", null), ESeniority.Junior, ESpecialization.Corporate, ESpecialization.Corporate);
            LegalXEmployee j15 = new JuniorLawyer(22, "Symere", "Woods", DateTime.ParseExact("18-02-2013", "dd-MM-yyyy", null), DateTime.ParseExact("21-03-1994", "dd-MM-yyyy", null), ESeniority.Junior, ESpecialization.Corporate, ESpecialization.Corporate);
            LegalXEmployee j16 = new JuniorLawyer(23, "Shigeo", "Kageyama", DateTime.ParseExact("06-05-1993", "dd-MM-yyyy", null), DateTime.ParseExact("24-07-1988", "dd-MM-yyyy", null), ESeniority.Junior, ESpecialization.CriminalCase, ESpecialization.CriminalCase);
            LegalXEmployee j17 = new JuniorLawyer(24, "Jake", "Gyllenhaal", DateTime.ParseExact("02-01-2004", "dd-MM-yyyy", null), DateTime.ParseExact("27-09-1993", "dd-MM-yyyy", null), ESeniority.Junior, ESpecialization.Corporate, ESpecialization.Corporate);
            LegalXEmployee j18 = new JuniorLawyer(25, "Ryan", "Reynolds", DateTime.ParseExact("19-11-1999", "dd-MM-yyyy", null), DateTime.ParseExact("24-07-1989", "dd-MM-yyyy", null), ESeniority.Junior, ESpecialization.FamilyCase, ESpecialization.FamilyCase);
            LegalXEmployee j19 = new JuniorLawyer(26, "John", "Snow", DateTime.ParseExact("29-12-2004", "dd-MM-yyyy", null), DateTime.ParseExact("30-04-1990", "dd-MM-yyyy", null), ESeniority.Junior, ESpecialization.CriminalCase, ESpecialization.CriminalCase);

            Employees.Add(j1);
            Employees.Add(j2);
            Employees.Add(j3);
            Employees.Add(j4);
            Employees.Add(j5);
            Employees.Add(j6);
            Employees.Add(j7);
            Employees.Add(j8);
            Employees.Add(j9);
            Employees.Add(j10);
            Employees.Add(j11);
            Employees.Add(j12);
            Employees.Add(j13);
            Employees.Add(j14);
            Employees.Add(j15);
            Employees.Add(j16);
            Employees.Add(j17);
            Employees.Add(j18);
            Employees.Add(j19);

            //Admin Staff Init
            LegalXEmployee a1 = new AdminStaff(27, "Frederick", "Tipton", DateTime.ParseExact("01-05-1990", "dd-MM-yyyy", null), "Assistant");
            LegalXEmployee a2 = new AdminStaff(28, "Jermaine", "Cole", DateTime.ParseExact("01-11-1987", "dd-MM-yyyy", null), "Coordinator");
            LegalXEmployee a3 = new AdminStaff(29, "Kendrick", "Duckworth", DateTime.ParseExact("01-10-1983", "dd-MM-yyyy", null), "Officer");

            Employees.Add(a1);
            Employees.Add(a2);
            Employees.Add(a3);

            //Receptionist Init
            Receptionist r1 = new Receptionist(30, "Scott", "Mescudi", DateTime.ParseExact("09-11-1995", "dd-MM-yyyy", null));
            Employees.Add(r1);



            //Cases init
            Case case1 = new Case(31, 3, ECaseType.Corporate, DateTime.ParseExact("14-10-2026", "dd-MM-yyyy", null), 12000, 19, "Murder case", "No notes");
            Case case2 = new Case(32, 3, ECaseType.Criminal, DateTime.ParseExact("10-07-2022", "dd-MM-yyyy", null), 14000, 17, "Financial Crime", "A lot of money is involved");
            Case case3 = new Case(33, 3, ECaseType.Family, DateTime.ParseExact("05-02-2022", "dd-MM-yyyy", null), 16000, 7, "Child Custody", "No notes");
            Case case4 = new Case(34, 3, ECaseType.Criminal, DateTime.ParseExact("23-02-2022", "dd-MM-yyyy", null), 12000, 12, "Murder case", "No notes");

            Cases.Add(case1);
            Cases.Add(case2);
            Cases.Add(case3);
            Cases.Add(case4);

            //Clients init
            Client client1 = new Client(35, "Sercan", "Ezhel", "Ipekcioglu", DateTime.ParseExact("20-10-1993", "dd-MM-yyyy", null), "Higashiyama-ku", "12", "605-0965", "Kyoto");
            Client client2 = new Client(36, "Onder", "", "Dogan", DateTime.ParseExact("05-11-1995", "dd-MM-yyyy", null), "Westend", "12, 2.tv.", "1620", "Vesterbro");
            Client client3 = new Client(37, "Sana", "", "Minatozaki", DateTime.ParseExact("17-04-1981", "dd-MM-yyyy", null), "Rodeo Drive", "12", "90210", "Beverly Hills");
            Client client4 = new Client(38, "Yoo", "", "Jeong-yeon", DateTime.ParseExact("22-02-1976", "dd-MM-yyyy", null), "China Town Street", "232", "10002", "Manhattan");

            Clients.Add(client1);
            Clients.Add(client2);
            Clients.Add(client3);
            Clients.Add(client4);

            //Appointments init
            Appointment appointment1 = new Appointment(39, 2, 3, DateTime.ParseExact("21-10-2021 11:30 AM", "dd-MM-yyyy h:mm tt", null), EMeetingRoom.Warrior, "Meeting up with client to check how they are");
            Appointment appointment2 = new Appointment(40, 2, 3, DateTime.ParseExact("24-10-2021 12:30 PM", "dd-MM-yyyy h:mm tt", null), EMeetingRoom.SOS, "Meeting about tax fraud");
            Appointment appointment3 = new Appointment(41, 2, 3, DateTime.ParseExact("02-11-2021 1:30 PM", "dd-MM-yyyy h:mm tt", null), EMeetingRoom.Cube, "Check up how client is doing");
            Appointment appointment4 = new Appointment(42, 2, 3, DateTime.ParseExact("14-12-2021 4:00 PM", "dd-MM-yyyy h:mm tt", null), EMeetingRoom.Cave, "Follow up on clients criminal case");

            Appointments.Add(appointment1);
            Appointments.Add(appointment2);
            Appointments.Add(appointment3);
            Appointments.Add(appointment4);

        }

    }
}
