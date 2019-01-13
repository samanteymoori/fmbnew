using FMB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMB.Model
{
    public class Patient
    {
        public string AccountNumber { get; set; }
        public string PTAccountNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string SSN { get; set; }
        public string PatientID { get; set; }
        public string Exported { get; set; }
        public string Status { get; set; }
        public string AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ProviderCode { get; set; }
        public string TerminateFlag { get; set; }
        public string ReferringPhysician { get; set; }
        public string DateOfInjury { get; set; }
        public string DateOfSimilarIllness { get; set; }
        public string PriorAuthorizationNumber { get; set; }
        public string DLNumber { get; set; }
        public string DLState { get; set; }
        public string rfid { get; set; }
        public string gblID { get; set; }
        public string Generation { get; set; }

        

    }
}
