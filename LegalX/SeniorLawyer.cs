using System;
namespace LegalX
{
    public class SeniorLawyer : Lawyer, IGeneralProperties, IEmployeeProperties
    {
        //Constructor
        public SeniorLawyer(int id, string firstName, string lastName, DateTime joinedOn, DateTime dob, ESeniority seniority, ESpecialization specialization, ESpecialization expertiseDomain) : base(id, firstName, lastName, joinedOn, dob, seniority, specialization, expertiseDomain)
        {
        }
    }
}