using System;
using System.Text;

namespace LegalX
{
    public class Client : IDescriptionOutput, IGeneralProperties
    {
        //Properties
        DateTime dob;

        public int Id { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        DateTime DOB
        {
            get { return dob; }
            set
            {
                if (value < DateTime.Now && value > DateTime.Now.AddYears(-100)) //Client can max be 100 years old
                {
                    dob = value;
                }
                else
                {
                    throw new Exception("Invalid date of birth entered\n" +
                        "Client must be born minimum today and cannot be more than 100 years old\n" +
                        "Try again, contact admin if problem persists");
                }
            }
        }
        string Street { get; set; }
        string StreetNr { get; set; }
        string Zip { get; set; }
        string City { get; set; }

        //Constructor
        public Client(int id, string firstName, string middleName, string lastName, DateTime dob, string street, string streetNr, string zip, string city)
        {
            Id = id;
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            DOB = dob;
            Street = street;
            StreetNr = streetNr;
            Zip = zip;
            City = city;
        }

        //Methods
        public string GenerateDescription()
        {
            StringBuilder textOutput = new StringBuilder();
            textOutput.AppendLine($"Id: {Id}");
            textOutput.AppendLine($"Firstname: {FirstName}");
            textOutput.AppendLine($"MiddleName: {MiddleName}");
            textOutput.AppendLine($"Lastname: {LastName}");
            textOutput.AppendLine($"DOB: {DOB.ToString("dd-MM-yyyy")}");
            textOutput.AppendLine($"Street: {Street}");
            textOutput.AppendLine($"StreetNr: {StreetNr}");
            textOutput.AppendLine($"Zip: {Zip}");
            textOutput.AppendLine($"City: {City}");
            return textOutput.ToString();
        }
    }

}
