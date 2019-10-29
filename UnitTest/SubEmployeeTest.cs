using BIL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class SubEmployeeTest : BaseEmployeeTest
    {
        public SubEmployeeTest()
        {
            Employee = new SubEmployee(Name, Position, Salary);
        }
    }
}
