using FMB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMB.Model
{
    public class PatientViewModel
    {
        public Address Address { get; set; }

        public Address BillingAddress { get; set; }

        public Phone Phone1 { get; set; }

        public Phone Phone2 { get; set; }

        public Insured PrimaryInsured { get; set; }

        public Insured SecondaryInsured { get; set; }

        public Insured OtherInsured { get; set; }

        public PatientHist PatientHist { get; set; }

        public Patient Patient { get; set; }

        public Phone InsuredPhone1 { get; set; }

        public Phone InsuredPhone2 { get; set; }

        public Address InsuredAddress { get; set; }

        public Guarantor Guarantor { get; set; }

        public Phone GuarantorPhone1 { get; set; }

        public Phone GuarantorPhone2 { get; set; }

        public Address GuarantorAddress { get; set; }

        public Provider Provider { get; set; }

        public NPIModel NPI { get; set; }
        public List<Provider> Providers { get; set; }

        public List<ServiceType> ServiceTypes { get; set; }

        public List<PlaceOfService> PlaceOfServices { get; set; }

        public List<Payer> Payers { get; set; }


    }
}
