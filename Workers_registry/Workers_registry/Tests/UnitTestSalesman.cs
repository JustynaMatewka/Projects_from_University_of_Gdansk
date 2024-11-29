namespace Workers_registry
{
    [TestFixture]
    public class TestSalesman
    {
        Salesman Salesman = new Salesman("03", "Alan", "Happy", 45, 5, "Main Street", "123", "A", "Sopot", 80.0, "WYSOKA");

        [SetUp]
        public void Setup3()
        {
        }

        [Test]
        public void CheckIfTestWorks3()
        {
            Assert.Pass();
        }


        //  Testing Salesman class:

        [Test]
        public void SalesmanEffectiveness()
        {
            Assert.AreEqual("WYSOKA", Salesman.Effectiveness);
        }
        /*[Test]
        public void SalesmanEffectivenessError()
        {
            Assert.AreEqual("Skuteczność inna niż oczekiwana", Salesman.Effectiveness);
        }*/
        [Test]
        public void SalesmanCommission()
        {
            Assert.AreEqual(80.0, Salesman.Commission);
        }
        /*[Test]
        public void SalesmanCommissionError()
        {
            Assert.AreEqual("Wysokość prowizji poza zakresem procentowym", Salesman.Commission);
        }*/
        [Test]
        public void SalesmanEmployeeId()
        {
            Assert.AreEqual("03", Salesman.EmployeeId);
        }
        [Test]
        public void SalesmanFirstName()
        {
            Assert.AreEqual("Alan", Salesman.FirstName);
        }
        [Test]
        public void SalesmanOfficeLastName()
        {
            Assert.AreEqual("Happy", Salesman.LastName);
        }
        [Test]
        public void SalesmanAge()
        {
            Assert.AreEqual(45, Salesman.Age);
        }
        [Test]
        public void SalesmanExperience()
        {
            Assert.AreEqual(5, Salesman.Experience);
        }
        [Test]
        public void SalesmanStreet()
        {
            Assert.AreEqual("Main Street", Salesman.Street);
        }
        [Test]
        public void SalesmanBuilding()
        {
            Assert.AreEqual("123", Salesman.Building);
        }
        [Test]
        public void SalesmanPlace()
        {
            Assert.AreEqual("A", Salesman.Place);
        }
        [Test]
        public void SalesmanCity()
        {
            Assert.AreEqual("Sopot", Salesman.City);
        }

    }
}