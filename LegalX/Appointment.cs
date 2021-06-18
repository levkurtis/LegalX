using System;
using System.Text;

namespace LegalX
{
    public class Appointment : IDescriptionOutput, IGeneralProperties
    {
        //Properties
        DateTime dateTime;

        public int Id { get; set; }
        int ClientId { get; set; }
        int LawyerId { get; set; }
        DateTime Datetime
        {
            get { return dateTime; }
            set
            {
                if (value > DateTime.Now)
                {
                    dateTime = value;
                }
                else
                {
                    throw new Exception($"Invalid date time entered\nAppointment date must be later than today ({DateTime.Now.ToString("dd-MM-yyyy")})");
                }
            }
        }
        EMeetingRoom MeetingRoom { get; set; } // Warrior, SOS, Cube or Cave
        string ShortDescription { get; set; }


        //Constructor
        public Appointment(int id, int clientId, int lawyerId, DateTime dateTime, EMeetingRoom meetingRoom, string shortDescription)
        {
            Id = id;
            ClientId = clientId;
            LawyerId = lawyerId;
            Datetime = dateTime;
            MeetingRoom = meetingRoom;
            ShortDescription = shortDescription;
        }

        //Method
        public string GenerateDescription()
        {
            StringBuilder textOutput = new StringBuilder();
            textOutput.AppendLine($"Id: {Id}");
            textOutput.AppendLine($"Client Id: {ClientId}");
            textOutput.AppendLine($"Lawyer type: {LawyerId}");
            textOutput.AppendLine($"Datetime: {Datetime.ToString("dd-MM-yyyy hh:mm tt")}");
            textOutput.AppendLine($"Meeting room: {MeetingRoom}");
            textOutput.AppendLine($"Short Description: {ShortDescription}");
            return textOutput.ToString();
        }
    }

    //Enumerator
    public enum EMeetingRoom
    {
        Unknown = 0, Warrior = 1, SOS = 2, Cube = 3, Cave = 4
    }


}
