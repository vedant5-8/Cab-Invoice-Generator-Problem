
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
                Rides[] rides = { new Rides(15.5, 5), new Rides(180, 240) };

                RideRepository repository = new RideRepository();

                repository.AddRide("mike", rides);

                List<Rides> listOfRides = repository.GetRides(UserID: "jack");

            }
            catch (InvoiceGeneratorException ex)
            {
                Assert.AreEqual("Invalid User ID", ex.Message);
            }

        }

        [TestMethod]
        public void TestMethod5()
        {
            InvoiceGenerator invoice = new InvoiceGenerator(Ride_Type.NORMAL);

            Rides[] rides = { new Rides(15.5, 5), new Rides(180, 240) };

            RideRepository repository = new RideRepository();

            repository.AddRide("mike", rides);

            List<Rides> listOfRides = repository.GetRides(UserID: "mike");

            InvoiceSummary summary = invoice.CalculateFare(listOfRides.ToArray());

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

        [TestMethod]
        public void TestMethod6()
        {
            InvoiceGenerator invoice = new InvoiceGenerator(Ride_Type.PREMIUM);

            Rides[] rides = { new Rides(15.5, 5), new Rides(180, 240) };

            RideRepository repository = new RideRepository();

            repository.AddRide("mike", rides);

            List<Rides> listOfRides = repository.GetRides(UserID: "mike");

            InvoiceSummary summary = invoice.CalculateFare(listOfRides.ToArray());

            int actualNoOfRides = summary.NoOfRides;
            double actualTotalFare = summary.TotalFare;
            double actualAvgFare = summary.AverageFare;

            int expectedNoOfRides = 2;
            double expectedTotalFare = 3422.5;
            double expectedAvgFare = 1711.25;

            Assert.AreEqual(expectedNoOfRides, actualNoOfRides);
            Assert.AreEqual(expectedTotalFare, actualTotalFare);
            Assert.AreEqual(expectedAvgFare, actualAvgFare);
        }

    }
}