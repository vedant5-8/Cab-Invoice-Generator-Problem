
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

            double expected = 150;

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

        [TestMethod]
        public void TestMethod4()
        {
            InvoiceGenerator invoice = new InvoiceGenerator();

            Rides[] rides = { new Rides(15.5, 5), new Rides(180, 240) };

            double actual = invoice.CalculateFair(rides);

            double expected = 2200;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod5()
        {
            InvoiceGenerator invoice = new InvoiceGenerator();

            try
            {
                Rides[] rides = { new Rides(15.5, 0), new Rides(180, 240) };

                double actual = invoice.CalculateFair(rides);
            }
            catch (InvoiceGeneratorException ex)
            {
                Assert.AreEqual("Invalid Time", ex.Message);
            }

        }

        [TestMethod]
        public void TestMethod6()
        {
            InvoiceGenerator invoice = new InvoiceGenerator();

            try
            {
                Rides[] rides = { new Rides(15.5, 5), new Rides(0, 240) };

                double actual = invoice.CalculateFair(rides);
            }
            catch (InvoiceGeneratorException ex)
            {
                Assert.AreEqual("Invalid Distance", ex.Message);
            }

        }
    }
}