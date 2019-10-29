using System.Collections.Generic;

namespace BIL
{
    public interface ISubordinateBehaviour
    {
        void Add(List<EmployeeComponent> employeesList, EmployeeComponent[] employees);
    }
}
