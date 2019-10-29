using System;
using BIL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public abstract class BaseEmployeeTest
    {
        protected EmployeeComponent Employee;
        protected readonly string Name = "Vasya";
        protected readonly string Position = "manager";
        protected readonly int Salary = 5;
        [TestMethod]
        public virtual void TestCreation()
        {
            Assert.AreEqual(Name, Employee.Name);
            Assert.AreEqual(Position, Employee.Position);
            Assert.AreEqual(Salary, Employee.Salary);
        }
    }
}
