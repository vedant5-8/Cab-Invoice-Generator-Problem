using Cab_Invoice_Generator_Problem;

namespace Cab_Invoice_Generator_Problem
{
    public class RideRepository
    {
        private Dictionary<string, List<Rides>> userRidesDictionary = new Dictionary<string, List<Rides>>();
        public void AddRide(string UserID, Rides[] rides)
        {
            if (rides == null)
            {
                throw new InvoiceGeneratorException(InvoiceGeneratorException.Type.NULL_RIDES, "Null Rides");
            }

            if (userRidesDictionary.ContainsKey(UserID))
            {
                userRidesDictionary[UserID].AddRange(rides);
            }
            else
            {
                userRidesDictionary.Add(UserID, new List<Rides>());
                userRidesDictionary[UserID].AddRange(rides);
            }
        }

        public List<Rides> GetRides(string UserID)
        {
            if (!userRidesDictionary.ContainsKey(UserID))
            {
                throw new InvoiceGeneratorException(InvoiceGeneratorException.Type.INVALID_USERID, "Invalid User ID");
            }

            return userRidesDictionary[UserID];

        }

    }
}
