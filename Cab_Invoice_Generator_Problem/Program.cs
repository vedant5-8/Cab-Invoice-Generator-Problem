
using Cab_Invoice_Generator_Problem;

try
{
    InvoiceGenerator invoice = new InvoiceGenerator();

    Console.WriteLine("Fare of one ride: {0} ", invoice.CalculateFare(5, 10));

    Console.WriteLine();

    Rides[] rides = { new Rides(2.5, 5), new Rides(30, 50), new Rides(500, 600) };

    InvoiceSummary summary = invoice.CalculateFare(rides);

    Console.WriteLine("Number of Rides: {0}", summary.NoOfRides);
    Console.WriteLine("Total fare of multiple rides: {0}", summary.TotalFare);
    Console.WriteLine("Average of Fare per ride: {0}", summary.AverageFare);

} 
catch (InvoiceGeneratorException ex)
{
    Console.WriteLine(ex.Message);
}