
using Cab_Invoice_Generator_Problem;

try
{
    InvoiceGenerator invoice = new InvoiceGenerator(Ride_Type.NORMAL);

    Console.WriteLine("Fare of one ride: {0} ", invoice.CalculateFare(5, 10));

    Console.WriteLine();

    Rides[] ride1 = { new Rides(2.5, 5), new Rides(30, 50), new Rides(500, 600) };
    Rides[] ride2 = { new Rides(2, 5), new Rides(300, 400) };

    RideRepository repository = new RideRepository();

    repository.AddRide("mike", ride1);
    repository.AddRide("jack", ride2);

    List<Rides> listOfRides = repository.GetRides(UserID: "jack");

    int i = 0;
    foreach(var ride  in listOfRides)
    {
        i++;
        Console.WriteLine("Ride " + i);
        Console.WriteLine("Distance: {0} || Time: {1}", ride.Distance, ride.Time);
        Console.WriteLine();
    }

    InvoiceSummary summary = invoice.CalculateFare(listOfRides.ToArray());

    Console.WriteLine("Number of Rides: {0}", summary.NoOfRides);
    Console.WriteLine("Total fare of multiple rides: {0}", summary.TotalFare);
    Console.WriteLine("Average of Fare per ride: {0}", summary.AverageFare);
} 
catch (InvoiceGeneratorException ex)
{
    Console.WriteLine(ex.Message);
}