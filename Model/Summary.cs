using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMB.Model
{
    
    public class Summary
    {
        public long Charges { get; set; }

        public long InsurrancePayments { get; set; }

        public long Adjustments { get; set; }

        public double PatientPayments { get; set; }

        public double Balance { get; set; }

        public double Deductible { get; set; }

        public double CoPay { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int PatientId { get; set; }

        public string AccountNo { get; set; }
    }
}
