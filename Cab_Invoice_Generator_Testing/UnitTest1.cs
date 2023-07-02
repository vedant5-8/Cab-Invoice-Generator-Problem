
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

            double actual = invoice.CalculateFare(12, 30);

            double expected = 150;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod2()
        {
            InvoiceGenerator invoice = new InvoiceGenerator();

            try
            {
                double actual = invoice.CalculateFare(12, 0);
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
                double actual = invoice.CalculateFare(0, 10);
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

            try
            {
                Rides[] rides = null;

                invoice.CalculateFare(rides);
            }
            catch (InvoiceGeneratorException ex)
            {
                Assert.AreEqual("Null Rides", ex.Message);
            }

        }

        [TestMethod]
        public void TestMethod5()
        {
            InvoiceGenerator invoice = new InvoiceGenerator();

            Rides[] rides = { new Rides(15.5, 5), new Rides(180, 240) };

            InvoiceSummary summary = invoice.CalculateFare(rides);

            int actualNoOfRides = summary.NoOfRides;
            double actualTotalFare = summary.TotalFare;
            double actualAvgFare = summary.AverageFare;

            int expectedNoOfRides = 2;
            double expectedTotalFare = 2200;
            double expectedAvgFare = 1100;

            Assert.AreEqual(expectedNoOfRides, actualNoOfRides);
            Assert.AreEqual(expectedTotalFare, actualTotalFare);
            Assert.AreEqual(expectedAvgFare, actualAvgFare);
        }


    }
}