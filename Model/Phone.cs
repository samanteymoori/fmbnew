using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMB.Model
{
    public class Phone
    {
        public string PhoneID { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
        public string Extension { get; set; }
        public string Exported { get; set; }
        public string AddedBy { get; set; }
        public string AddedDate { get; set; }
    }
}
