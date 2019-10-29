using BIL.Output;

namespace BIL
{
    public class EmployeeVisitor:IVisitor
    {

        public string Visit(Employee employee)
        {
           return "Can has subordinates";
        }

        public string Visit(SubEmployee subEmployee)
        {
            return "Cannot has subordinates";
        }
    }
}
