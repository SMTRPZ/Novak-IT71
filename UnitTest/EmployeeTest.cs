using BIL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class EmployeeTest : BaseEmployeeTest
    {
        public EmployeeTest()
        {
            Employee = new Employee(Name, Position, Salary);
        }
        [TestMethod]
        public void TestAdding()
        {
            SubEmployee subEmployee = new SubEmployee("Vasya2", Position, 44);
            Assert.AreEqual(0, ((Employee) Employee).Employees.Count);
            Employee.Add(subEmployee);
            Assert.AreEqual(1, ((Employee)Employee).Employees.Count);
            Assert.AreSame(subEmployee, ((Employee)Employee).Employees[0]);
        }
    }
}
