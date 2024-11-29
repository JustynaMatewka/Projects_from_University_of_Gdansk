namespace Workers_registry
{
    [TestFixture]
    public class TestManualWorker
    {
        ManualWorker ManualWorker = new ManualWorker("02", "Jane", "Smith", 25, 3, "Broad Street", "456", "B", "Town", 80);

        [SetUp]
        public void Setup2()
        {
        }

        [Test]
        public void CheckIfTestWorks2()
        {
            Assert.Pass();
        }


        //  Testing ManualWorker class:

        [Test]
        public void ManualWorkerPhysicalStrength()
        {
            Assert.AreEqual(80, ManualWorker.PhysicalStrength);
        }
        [Test]

        public void ManualWorkerEmployeeId()
        {
            Assert.AreEqual("02", ManualWorker.EmployeeId);
        }
        [Test]
        public void ManualWorkerFirstName()
        {
            Assert.AreEqual("Jane", ManualWorker.FirstName);
        }
        [Test]
        public void ManualWorkerManualLastName()
        {
            Assert.AreEqual("Smith", ManualWorker.LastName);
        }
        [Test]
        public void ManualWorkerAge()
        {
            Assert.AreEqual(25, ManualWorker.Age);
        }
        [Test]
        public void ManualWorkerExperience()
        {
            Assert.AreEqual(3, ManualWorker.Experience);
        }
        [Test]
        public void ManualWorkerStreet()
        {
            Assert.AreEqual("Broad Street", ManualWorker.Street);
        }
        [Test]
        public void ManualWorkerBuilding()
        {
            Assert.AreEqual("456", ManualWorker.Building);
        }
        [Test]
        public void ManualWorkerPlace()
        {
            Assert.AreEqual("B", ManualWorker.Place);
        }
        [Test]
        public void ManualWorkerCity()
        {
            Assert.AreEqual("Town", ManualWorker.City);
        }

    }
}