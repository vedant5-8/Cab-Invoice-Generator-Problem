
using Cab_Invoice_Generator_Problem;

try
{
    InvoiceGenerator invoice = new InvoiceGenerator();

    Console.WriteLine("Fair of one ride: {0} ", invoice.CalculateFair(5, 10));

    Console.WriteLine();

    Rides[] rides = { new Rides(2.5, 5), new Rides(30, 50) };

    double TotalFair = invoice.CalculateFair(rides);

    Console.WriteLine("Total fair of multiple rides: {0}", TotalFair);

} 
catch (InvoiceGeneratorException ex)
{
    Console.WriteLine(ex.Message);
}