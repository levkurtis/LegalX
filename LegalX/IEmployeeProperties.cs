using System;
namespace LegalX
{
    public interface IEmployeeProperties //All Employees will have ID, firstname, lastName, JoinedOn
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime JoinedOn { get; set; }
    }
}
