
namespace Cab_Invoice_Generator_Problem
{
    public class InvoiceGenerator
    {
        readonly int Cost_Per_KM = 10;
        readonly int Cost_Per_MINUTE = 1;

        public double CalculateFair(double Distance, double Time)
        {
            if (Time == 0)
            {
                throw new InvoiceGeneratorException(InvoiceGeneratorException.Type.INVALID_TIME, "Invalid Time");
            } 

            if (Distance == 0)
            {
                throw new InvoiceGeneratorException(InvoiceGeneratorException.Type.INVALID_DISTANCE, "Invalid Distance");
            }
            double fair = Distance * Cost_Per_KM + Time * Cost_Per_MINUTE;
            return Math.Max(5, fair);
        }

        public double CalculateFair(Rides[] rides)
        {
            if (rides == null)
            {
                throw new InvoiceGeneratorException(InvoiceGeneratorException.Type.NULL_RIDES, "Null Rides");
            }

            double totalFair = 0;

            foreach (var ride in rides)
            {
                totalFair = totalFair + CalculateFair(ride.Distance, ride.Time);
            }

            return totalFair;
        }

    }
}
