using System;
using BIL;
using BIL.Output;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class CompanyTest
    {
        [TestMethod]
        public void TestCompanyWithEmployees()
        {
            IOutput stringOutput = new StringOutput();
            EmployeeComponent director = new Employee("Director", "director", 20);
            EmployeeComponent manager = new Employee("Manager of storing", "manager", 15);
            EmployeeComponent manager2 = new Employee("Manager of marketing", "manager", 12);
            EmployeeComponent x = new SubEmployee("X", "team group", 10);
            EmployeeComponent y = new SubEmployee("Y", "team group", 10);
            EmployeeComponent a = new SubEmployee("A", "team group", 10);
            EmployeeComponent b = new SubEmployee("B", "team group", 10);
            EmployeeComponent c = new SubEmployee("Another one manager", "manager", 10);
            director.Add(manager, manager2);
            manager.Add(x, y, c);
            manager2.Add(a, b);
            Company company = new Company(director, stringOutput);
            PrivateObject obj = new PrivateObject(company);
            var root = obj.GetField("_root");
            Assert.IsTrue(root is Employee);
            Assert.AreSame(director,root);
            Assert.IsTrue(((EmployeeComponent)root).Name == "Director");
            Assert.IsTrue(((Employee)root).Employees.Count==2);
        }
    }
}
