using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cab_Invoice_Generator_Problem
{
    public class InvoiceSummary
    {
        public int NoOfRides;
        public double TotalFare;
        public double AverageFare;

        public InvoiceSummary(int noOfRides, double totalFare, double averageFare)
        {
            NoOfRides = noOfRides;
            TotalFare = totalFare;
            AverageFare = averageFare;
        }
    }
}
