using System;
using BIL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public abstract class BaseSubordinatesBehaviourTest
    {
        protected EmployeeComponent employee;
        [TestMethod]
        public virtual void Test()
        {
            PrivateObject obj = new PrivateObject(employee);
            var behaviour = obj.GetField("_behaviour");
            Assert.IsTrue(behaviour.GetType() == GetSupportedType());
            Assert.IsTrue(behaviour is ISubordinateBehaviour);
        }

        public abstract Type GetSupportedType();
    }
}
