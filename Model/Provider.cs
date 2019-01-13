using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMB.Model
{
    //DONE Implement Provider model
    public class Provider
    {
        public string ClientCode { get; set; }
        public string ProviderCode { get; set; }
        public string CRNAPCPFlag { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public string UPIN { get; set; }
        public string SSN { get; set; }
        public string DateOfBirth { get; set; }
        public string ProviderID { get; set; }
        public string Exported { get; set; }
        public string Status { get; set; }
        public string AddedBy { get; set; }
        public string AddedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string Encounter { get; set; }
        public string FacilityID { get; set; }
        public string MedicaidNumber { get; set; }
    }
}
