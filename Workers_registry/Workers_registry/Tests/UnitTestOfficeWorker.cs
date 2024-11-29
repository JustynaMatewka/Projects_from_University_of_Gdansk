namespace Workers_registry
{
    [TestFixture]
    public class TestOfficeWorker
    {
        OfficeWorker officeWorker = new OfficeWorker("01", "John", "Doe", 30, 5, "Main Street", "123", "A", "City", 120, "OW1");

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckIfTestWorks()
        {
            Assert.Pass();
        }

        //  Testing OfficeWorker class:

        [Test]
        public void OfficeWorkerIQ()
        {
            Assert.AreEqual(120, officeWorker.IQ);
        }
        [Test]
        public void OfficeWorkerOfficeEmployeeId()
        {
            Assert.AreEqual("OW1", officeWorker.OfficeEmployeeId);
        }
        [Test]
        public void OfficeWorkerEmployeeId()
        {
            Assert.AreEqual("01", officeWorker.EmployeeId);
        }
        [Test]
        public void OfficeWorkerFirstName()
        {
            Assert.AreEqual("John", officeWorker.FirstName);
        }
        [Test]
        public void OfficeWorkerOfficeLastName()
        {
            Assert.AreEqual("Doe", officeWorker.LastName);
        }
        [Test]
        public void OfficeWorkerAge()
        {
            Assert.AreEqual(30, officeWorker.Age);
        }
        [Test]
        public void OfficeWorkerExperience()
        {
            Assert.AreEqual(5, officeWorker.Experience);
        }
        [Test]
        public void OfficeWorkerStreet()
        {
            Assert.AreEqual("Main Street", officeWorker.Street);
        }
        [Test]
        public void OfficeWorkerBuilding()
        {
            Assert.AreEqual("123", officeWorker.Building);
        }
        [Test]
        public void OfficeWorkerPlace()
        {
            Assert.AreEqual("A", officeWorker.Place);
        }
        [Test]
        public void OfficeWorkerCity()
        {
            Assert.AreEqual("City", officeWorker.City);
        }

    }
}