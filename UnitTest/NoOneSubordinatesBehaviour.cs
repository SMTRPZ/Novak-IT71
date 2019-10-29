using System;
using BIL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class NoOneSubordinatesBahavior: BaseSubordinatesBehaviourTest
    {
        public NoOneSubordinatesBahavior()
        {
            employee=new SubEmployee("Vasya","manager",5);
        }

        public override Type GetSupportedType()
        {
            return typeof(NoOneSubordinatesBehaviour);
        }
    }
}
