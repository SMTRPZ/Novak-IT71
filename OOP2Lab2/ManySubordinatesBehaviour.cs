using System.Collections.Generic;

namespace BIL
{
    public class ManySubordinatesBehaviour:ISubordinateBehaviour
    {
        public void Add(List<EmployeeComponent> employeeList, params EmployeeComponent[] employees)
        {
            foreach (var employee in employees)
            {
                employeeList.Add(employee);
            }
        }
    }
}
