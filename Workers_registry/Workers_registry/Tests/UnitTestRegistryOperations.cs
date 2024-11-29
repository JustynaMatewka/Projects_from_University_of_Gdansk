using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers_registry.Tests
{
    [TestFixture]
    internal class UnitTestRegistryOperations
    {

        [Test]
        public void AddEmployeeToList_Success()
        {
            // Arrange
            var addEmployee = new AddEmployee();
            var newEmployee = new OfficeWorker("11", "John", "Doe", 30, 5, "Main Street", "123", "A", "City", 120, "OW1");
            var registry = Registry.Instance.Employees;
            Console.WriteLine("Przed testem dodawania: ");
            Console.WriteLine("Liczba elementów liście: " + registry.Count);


            // Act
            addEmployee.AddE(newEmployee);

            // Assert
            Assert.IsTrue(registry.Contains(newEmployee));

            Console.WriteLine("Po teście dodawania: ");
            Console.WriteLine("Liczba elementów liście: " + registry.Count);
        }

        [Test]
        public void AddEmployeeToList_DuplicateId_Fails()
        {
            // Arrange
            var addEmployee = new AddEmployee();
            var existingEmployee = new OfficeWorker("1", "John", "Doe", 30, 5, "Main Street", "123", "A", "City", 120, "OW1");
            var newEmployee = new OfficeWorker("1", "Jane", "Smith", 25, 3, "Broad Street", "456", "B", "Town", 130, "OW2");

            // Act
            addEmployee.AddE(existingEmployee);
            addEmployee.AddE(newEmployee);

            // Assert
            var registry = Registry.Instance.Employees;
            Assert.IsFalse(registry.Contains(newEmployee));
        }

        [Test]
        public void removeEmployee_Success()
        {
            // Arrange
            var removeEmployee = new RemoveEmployee();
            var registry = Registry.Instance.Employees;
            int check = 0;

            // Act
            removeEmployee.RemoveE("11");

            // Assert
            foreach (var item in registry)
            {
                Console.WriteLine(item.EmployeeId);
                if (item.EmployeeId == "11")
                {
                    check = 1;
                }
            }
            Assert.IsTrue(check == 0);

            Console.WriteLine("Liczba elementów liście: " + registry.Count);
            Console.WriteLine("Lista ID pracowników w liście: ");
            foreach (var item in registry)
            {
                Console.Write(item.EmployeeId);
            }
        }

        [Test]
        public void removeEmployee_NotExisting()
        {
            // Arrange
            var removeEmployee = new RemoveEmployee();
            var registry = Registry.Instance.Employees;
            int check = 0;

            Console.WriteLine("Przed testem usuwania: ");
            Console.WriteLine("Liczba elementów liście: " + registry.Count); 

            // Act
            removeEmployee.RemoveE("11");

            // Assert

            foreach (var item in registry)
            {
                if (item.EmployeeId == "11")
                {
                    check = 1;
                }
            }
            Assert.IsTrue(check == 0);

            Console.WriteLine("Po teście usuwania: ");
            Console.WriteLine("Liczba elementów liście: " + registry.Count);
        }

        [Test]
        public void removeAllEmployees()
        {
            var clean = new RemoveAllEmployees();
            var registry = Registry.Instance.Employees;

            Console.WriteLine("Przed testem usuwania: ");
            Console.WriteLine("Liczba elementów liście: " + registry.Count);

            clean.RemoveAll();
            Assert.IsTrue(registry.Count == 0);

            Console.WriteLine("Po teście usuwania: ");
            Console.WriteLine("Liczba elementów liście: " + registry.Count);
        }

        [Test]
        public void viewSortedRegistry()
        {
            var addEmployee = new AddEmployee();
            var newEmployee1 = new OfficeWorker("01", "John", "Doe", 30, 5, "Main Street", "123", "A", "City", 120, "OW1");
            var newEmployee2 = new ManualWorker("02", "Jane", "Smith", 25, 3, "Broad Street", "456", "B", "Town", 80);
            var newEmployee3 = new Salesman("03", "Alan", "Happy", 45, 5, "Main Street", "123", "A", "City", 80.0, "WYSOKA");
            var newEmployee4 = new OfficeWorker("04", "David", "Douglas", 62, 23, "Broad Street", "456", "B", "Town", 130, "OW2");

            addEmployee.AddE(newEmployee1);
            addEmployee.AddE(newEmployee2);
            addEmployee.AddE(newEmployee3);
            addEmployee.AddE(newEmployee4);

            var registry = Registry.Instance.Employees;
            var list = new ViewEmployee();


            foreach (var item in list.FindE())
            {
                Console.WriteLine(item.EmployeeId + " " + item.Experience + " " + item.Age + " " + item.LastName);
            }

            var sortedEmployees = registry.OrderByDescending(e => e.Experience).ThenBy(e => e.Age).ThenBy(e => e.LastName).ToList();

            Assert.IsTrue(sortedEmployees.SequenceEqual(list.FindE()));
        }

        [Test]
        public void ViewEmployeesByCity()
        {
            var addEmployee = new AddEmployee();
            var newEmployee1 = new OfficeWorker("01", "John", "Doe", 30, 5, "Main Street", "123", "A", "City", 120, "OW1");
            var newEmployee2 = new ManualWorker("02", "Jane", "Smith", 25, 3, "Broad Street", "456", "B", "Town", 80);
            var newEmployee3 = new Salesman("03", "Alan", "Happy", 45, 5, "Main Street", "123", "A", "City", 80.0, "WYSOKA");
            var newEmployee4 = new OfficeWorker("04", "David", "Douglas", 62, 23, "Broad Street", "456", "B", "Town", 130, "OW2");

            addEmployee.AddE(newEmployee1);
            addEmployee.AddE(newEmployee2);
            addEmployee.AddE(newEmployee3);
            addEmployee.AddE(newEmployee4);

            var registry = Registry.Instance.Employees;
            var list = new ViewEmployeeByCity();


            foreach (var item in list.FindEmployeeByCity("City"))
            {
                Console.WriteLine(item.EmployeeId + " " + item.City + " " + item.LastName);
            }


            List<EmployeeInterface> foundCities = new List<EmployeeInterface>();

            foreach (EmployeeInterface employee in registry)
            {
                if (employee.City == "City")
                {
                    foundCities.Add(employee);
                }
            }

            Assert.IsTrue(foundCities.SequenceEqual(list.FindEmployeeByCity("City")));
        }

        [Test]
        public void ViewEmployeesWithValue()
        {
            var addEmployee = new AddEmployee();
            var newEmployee1 = new OfficeWorker("01", "John", "Doe", 30, 5, "Main Street", "123", "A", "City", 120, "OW1");
            var newEmployee2 = new ManualWorker("02", "Jane", "Smith", 25, 3, "Broad Street", "456", "B", "Town", 80);
            var newEmployee3 = new Salesman("03", "Alan", "Happy", 45, 5, "Main Street", "123", "A", "City", 80.0, "WYSOKA");
            var newEmployee4 = new OfficeWorker("04", "David", "Douglas", 62, 23, "Broad Street", "456", "B", "Town", 130, "OW2");

            addEmployee.AddE(newEmployee1);
            addEmployee.AddE(newEmployee2);
            addEmployee.AddE(newEmployee3);
            addEmployee.AddE(newEmployee4);

            var registry = Registry.Instance.Employees;
            var list = new ViewEmployeeWithValue();
            var employeeWithValue = new Dictionary<EmployeeInterface, double>();


            foreach (var item in registry)
            {
                Console.WriteLine(item.EmployeeId + " " + item.LastName + " " + item.EmployeeValue());
                employeeWithValue.Add(item, item.EmployeeValue());
            }

            Assert.IsTrue(employeeWithValue.SequenceEqual(list.View()));
        }
    }
}
