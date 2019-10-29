using BIL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class EmployeeComponentTest
    {
        [DataRow("Vasya", "manager", 5, false)]
        [DataRow("Vasya", "team group", 25, true)]
        [DataTestMethod]
        public virtual void GetFullInfoTest(string name, string position, int salary, bool isSubEmployee)
        {
            EmployeeComponent obj;
            if (isSubEmployee)
                obj = new SubEmployee(name, position, salary);
            else
                obj = new Employee(name, position, salary);
            Assert.IsTrue(obj.GetFullInfo().Contains(name));
            Assert.IsTrue(obj.GetFullInfo().Contains(position));
            Assert.IsTrue(obj.GetFullInfo().Contains(salary.ToString()));
        }

        [DataRow(38)]
        [DataTestMethod]
        public virtual void FindEmployeeWithSalaryHigherThan(int salary)
        {
            EmployeeComponent obj = new Employee("Vasya", "director", 16);
            EmployeeComponent obj2 = new Employee("Vasya", "manager", 27);
            EmployeeComponent obj3 = new Employee("Vasya", "manager", 28);
            EmployeeComponent obj4 = new Employee("Vasya", "team group", 100);
            obj.Add(obj2);
            obj2.Add(obj3);
            obj3.Add(obj4);
            Dictionary<string, List<EmployeeComponent>> actual = obj.FindEmployeeWithSalaryHigherThan(salary);
            Dictionary<string, List<EmployeeComponent>> expected = new Dictionary<string, List<EmployeeComponent>>
            {
                {"team group", new List<EmployeeComponent> {obj4}}
            };
            Assert.IsTrue(expected.Count == actual.Count);
        }
    }
}
