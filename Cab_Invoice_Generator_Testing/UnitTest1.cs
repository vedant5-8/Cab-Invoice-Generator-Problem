
using Cab_Invoice_Generator_Problem;

namespace Cab_Invoice_Generator_Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            InvoiceGenerator invoice = new InvoiceGenerator();

            double actual = invoice.CalculateFair(12, 30);

            double expected = 11;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            InvoiceGenerator invoice = new InvoiceGenerator();

            try
            {
                double actual = invoice.CalculateFair(12, 0);
            }
            catch (InvoiceGeneratorException ex)
            {
                Assert.AreEqual("Invalid Time", ex.Message);
            }

        }

        [TestMethod]
        public void TestMethod3()
        {
            InvoiceGenerator invoice = new InvoiceGenerator();

            try
            {
                double actual = invoice.CalculateFair(0, 10);
            }
            catch (InvoiceGeneratorException ex)
            {
                Assert.AreEqual("Invalid Distance", ex.Message);
            }

        }
    }
}