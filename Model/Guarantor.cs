using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMB.Model
{
    public class Guarantor
    {
        public string GuarantorID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string AddressID { get; set; }
        public string Phone1ID { get; set; }
        public string Phone2ID { get; set; }
        public string Relation { get; set; }
        public string EmployerID { get; set; }
        public string Gender { get; set; }
        public string Exported { get; set; }
        public string AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string Generation { get; set; }
    }
}
