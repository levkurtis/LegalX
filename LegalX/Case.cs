using System;
using System.Text;

namespace LegalX
{
    public class Case : IDescriptionOutput, IGeneralProperties
    {
        //Properties
        DateTime startDate;

        public int Id { get; set; }
        int CustomerId { get; set; }
        ECaseType Casetype { get; set; } //Corporate, Family or Criminal
        DateTime StartDate
        {
            get { return startDate; }
            set
            {
                if (value > DateTime.Now)
                {
                    startDate = value;
                }
                else
                {
                    throw new Exception($"Invalid date time entered\n" +
                        $"Date must be later than today ({DateTime.Now.ToString("dd-MM-yyyy")})");
                }
            }
        }

        int TotalCharges { get; set; }
        int LawyerId { get; set; }
        string CaseDescription { get; set; }
        string Notes { get; set; }

        //Constructor
        public Case(int id, int customerId, ECaseType caseType, DateTime startDate, int totalCharge, int lawyerId, string caseDescription, string notes)
        {
            Id = id;
            CustomerId = customerId;
            Casetype = caseType;
            StartDate = startDate;
            TotalCharges = totalCharge;
            LawyerId = lawyerId;
            CaseDescription = caseDescription;
            Notes = notes;
        }

        //Method
        public string GenerateDescription()
        {
            StringBuilder textOutput = new StringBuilder();
            textOutput.AppendLine($"Id: {Id}");
            textOutput.AppendLine($"Customer Id: {CustomerId}");
            textOutput.AppendLine($"Case type: {Casetype}");
            textOutput.AppendLine($"Startdate: {StartDate.ToString("dd-MM-yyyy")}");
            textOutput.AppendLine($"Total Charges: {TotalCharges}");
            textOutput.AppendLine($"Lawyer Id: {LawyerId}");
            textOutput.AppendLine($"Case Description: {CaseDescription}");
            textOutput.AppendLine($"Notes: {Notes}");
            return textOutput.ToString();
        }


    }

    //Enumerator
    public enum ECaseType
    {
        Unknown = 0, Corporate = 1, Family = 2, Criminal = 3
    }
}
