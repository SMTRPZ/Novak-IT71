using BIL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class ManySubordinatesBehaviourTest : BaseSubordinatesBehaviourTest
    {
        public ManySubordinatesBehaviourTest()
        {
            employee = new Employee("Vasya", "manager", 25);
        }

        public override Type GetSupportedType()
        {
            return typeof(ManySubordinatesBehaviour);
        }
    }
}
