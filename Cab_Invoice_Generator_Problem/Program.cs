
using Cab_Invoice_Generator_Problem;

try
{
    InvoiceGenerator invoice = new InvoiceGenerator();

    Console.WriteLine(invoice.CalculateFair(5, 10));
} 
catch (InvoiceGeneratorException ex)
{
    Console.WriteLine(ex.Message);
}