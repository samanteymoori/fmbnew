﻿using System;

namespace FMB.Services
{
    public class DashboardResult
    {
        public int claimnumber { get; set; }

        public string Patientfullname { get; set; }

        public string providerfullname { get; set; }

        public string Carriername { get; set; }

        public DateTime Datefiled { get; set; }

        public string DateFormat { get { return Datefiled.ToString("yyyy/MM/dd"); } }

        public string ClaimStatus { get; set; }

        public float Billed { get; set; }

        public int Insurance { get; set; }

        public int Adjustments { get; set; }

        public int PatientPay { get; set; }

        public int Balance { get; set; }

        public string Note { get; set; }

        public int Action { get; set; }

        public int VirtualItemCount { get; set; }

        public int rn { get; set; }

        public int PatientId { get; set; }


    }
}