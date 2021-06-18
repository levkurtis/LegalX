using System;
namespace LegalX
{
    public class JuniorLawyer : Lawyer, IGeneralProperties, IEmployeeProperties
    {
        //Constructor
        public JuniorLawyer(int id, string firstName, string lastName, DateTime joinedOn, DateTime dob, ESeniority seniority, ESpecialization specialization, ESpecialization expertiseDomain) : base(id, firstName, lastName, joinedOn, dob, seniority, specialization, expertiseDomain)
        {
        }
    }
}