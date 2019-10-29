using BIL.Output;
using System.Collections.Generic;
using System.Linq;

namespace BIL
{
    public sealed class Company
    {
        private readonly EmployeeComponent _root;
        private readonly IOutput _output;
        public Company(EmployeeComponent root, IOutput output)
        {
            _root = root;
            _output = output;
        }

        public void PrintAllByPosition(string position)
        {
            _output.Print($"There are all employees with position {position}:");
            foreach (var employee in _root.GetAllWithPosition(position))
            {
                _output.Print(employee.ToString());
            }
        }
        public void PrintAllWithHighestSalaryAndHigherThan(int salary)
        {
            _output.Print($"There are all employees with salary higher than {salary}:");
            Dictionary<string, List<EmployeeComponent>> withHighestSalaryList = _root.FindEmployeeWithSalaryHigherThan(salary);

            foreach (KeyValuePair<string, List<EmployeeComponent>> keyValue in withHighestSalaryList)
            {
                IEnumerable<EmployeeComponent> withTheHighestSalaries =
                    keyValue.Value.Where(x => x.Salary == keyValue.Value.Max(y => y.Salary));
                _output.Print($"Position: {keyValue.Key}.");
                foreach (EmployeeComponent withTheHighestSalary in withTheHighestSalaries)
                {
                    _output.Print($"\tName: {withTheHighestSalary.Name}. Salary: {withTheHighestSalary.Salary}");
                }
            }
        }

        public void PrintAllWithParent(EmployeeComponent parent)
        {
            List<EmployeeComponent> employeesList = new List<EmployeeComponent>();
            _output.Print($"There are all subordinates of {parent}");
            foreach (EmployeeComponent employeeComponent in parent.FindAllSubOrdinate())
            {
                _output.Print(employeeComponent.ToString());
            }
        }
        public void PrintHierarchy()
        {
            _output.Print($"There are direct hierarchy of company:");
            _output.Print(_root.GetFullInfo());
        }
        public void PrintBackwards()
        {
            Dictionary<string, List<EmployeeComponent>> employees = new Dictionary<string, List<EmployeeComponent>>();
            _output.Print($"There are hierarchy of company by positions:");
            foreach (KeyValuePair<string, List<EmployeeComponent>> keyValue in _root.FindAllEmployees())
            {
                foreach (EmployeeComponent employee in keyValue.Value)
                {
                    _output.Print($"{employee}");
                }
            }
        }
    }
}
