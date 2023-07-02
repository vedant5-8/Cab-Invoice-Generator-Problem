
namespace Cab_Invoice_Generator_Problem
{
    public class InvoiceGenerator
    {
        readonly int Cost_Per_KM = 10;
        readonly int Cost_Per_MINUTE = 1;
        readonly int Mimimum_Fare = 5;

        public InvoiceGenerator()
        {
            
        }

        public InvoiceGenerator(Ride_Type rideType)
        {
            try
            {
                if (rideType.Equals(Ride_Type.NORMAL))
                {
                    Cost_Per_KM = 10;
                    Cost_Per_MINUTE = 1;
                    Mimimum_Fare = 5;
                }

                if (rideType.Equals(Ride_Type.PREMIUM))
                {
                    Cost_Per_KM = 15;
                    Cost_Per_MINUTE = 2;
                    Mimimum_Fare = 20;
                }
            }
            catch (InvoiceGeneratorException)
            {
                throw new InvoiceGeneratorException(InvoiceGeneratorException.Type.INVALID_RIDE_TYPE, "Invalid Ride Type Select Normal or Premium");
            }
        }

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
            return Math.Max(Mimimum_Fare, Fare);
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
