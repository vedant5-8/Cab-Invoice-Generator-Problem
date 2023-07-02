
namespace Cab_Invoice_Generator_Problem
{
    public class InvoiceGenerator
    {
        readonly int Cost_Per_KM = 10;
        readonly int Cost_Per_MINUTE = 1;

        public double CalculateFare(double Distance, double Time)
        {
            if (Time == 0)
            {
                throw new InvoiceGeneratorException(InvoiceGeneratorException.Type.INVALID_TIME, "Invalid Time");
            } 

            if (Distance == 0)
            {
                throw new InvoiceGeneratorException(InvoiceGeneratorException.Type.INVALID_DISTANCE, "Invalid Distance");
            }
            double Fare = Distance * Cost_Per_KM + Time * Cost_Per_MINUTE;
            return Math.Max(5, Fare);
        }

        public InvoiceSummary CalculateFare(Rides[] rides)
        {
            if (rides == null)
            {
                throw new InvoiceGeneratorException(InvoiceGeneratorException.Type.NULL_RIDES, "Null Rides");
            }

            double totalFare = 0;

            foreach (Rides ride in rides)
            {
                totalFare = totalFare + CalculateFare(ride.Distance, ride.Time);
            }

            double AvgFare = totalFare / rides.Length;

            return new InvoiceSummary(rides.Length, totalFare, AvgFare);
        }

    }
}
