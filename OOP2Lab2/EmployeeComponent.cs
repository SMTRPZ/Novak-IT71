using BIL.Output;
using System.Collections;
using System.Collections.Generic;

namespace BIL
{
    public abstract class EmployeeComponent : IEmployee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }

        protected EmployeeComponent(string name, string position, int salary)
        {
            Name = name;
            Position = position;
            Salary = salary;
        }

        public virtual string GetFullInfo(string info = "")
        {

            info += ToString();
            IEnumerator iterator = CreateIterator();
            bool hasNext = iterator.MoveNext();
            while (hasNext)
            {
                EmployeeComponent employee = (EmployeeComponent)iterator.Current;
                info = employee.GetFullInfo(info);
                hasNext = iterator.MoveNext();
            }

            return info;
        }

        public virtual Dictionary<string, List<EmployeeComponent>> FindEmployeeWithSalaryHigherThan(int salary, Dictionary<string, List<EmployeeComponent>> withHighestSalaryList = null)
        {
            if (withHighestSalaryList == null) withHighestSalaryList = new Dictionary<string, List<EmployeeComponent>>();
            if (Salary > salary)
            {
                if (!withHighestSalaryList.ContainsKey(Position))
                {
                    List<EmployeeComponent> employees = new List<EmployeeComponent> { this };
                    withHighestSalaryList.Add(Position, employees);
                }
                else
                {
                    withHighestSalaryList[Position].Add(this);
                }
            }
            IEnumerator iterator = CreateIterator();
            bool hasNext = iterator.MoveNext();
            while (hasNext)
            {
                EmployeeComponent employee = (EmployeeComponent)iterator.Current;
                withHighestSalaryList = employee.FindEmployeeWithSalaryHigherThan(salary, withHighestSalaryList);
                hasNext = iterator.MoveNext();
            }

            return withHighestSalaryList;
        }
        public virtual List<EmployeeComponent> GetAllWithPosition(string position, List<EmployeeComponent> employees = null)
        {
            if (employees == null) employees = new List<EmployeeComponent>();
            if (Position == position)
            {
                employees.Add(this);
            }
            IEnumerator iterator = CreateIterator();
            bool hasNext = iterator.MoveNext();
            while (hasNext)
            {
                EmployeeComponent employee = (EmployeeComponent)iterator.Current;
                employees = employee.GetAllWithPosition(position, employees);
                hasNext = iterator.MoveNext();
            }

            return employees;
        }
        public List<EmployeeComponent> FindAllSubOrdinate(List<EmployeeComponent> subOrdinateList = null)
        {
            if (subOrdinateList == null) subOrdinateList = new List<EmployeeComponent>();
            IEnumerator iterator = CreateIterator();
            bool hasNext = iterator.MoveNext();
            while (hasNext)
            {
                EmployeeComponent employee = (EmployeeComponent)iterator.Current;
                subOrdinateList.Add(employee);
                subOrdinateList = employee.FindAllSubOrdinate(subOrdinateList);
                hasNext = iterator.MoveNext();
            }

            return subOrdinateList;
        }

        public Dictionary<string, List<EmployeeComponent>> FindAllEmployees(Dictionary<string, List<EmployeeComponent>> employeesWithPositions = null)
        {
            if (employeesWithPositions == null) employeesWithPositions = new Dictionary<string, List<EmployeeComponent>>();
            if (!employeesWithPositions.ContainsKey(Position))
            {
                List<EmployeeComponent> employees = new List<EmployeeComponent> { this };
                employeesWithPositions.Add(Position, employees);
            }
            else
            {
                employeesWithPositions[Position].Add(this);
            }
            IEnumerator iterator = CreateIterator();
            bool hasNext = iterator.MoveNext();
            while (hasNext)
            {
                EmployeeComponent employee = (EmployeeComponent)iterator.Current;
                employeesWithPositions = employee.FindAllEmployees(employeesWithPositions);
                hasNext = iterator.MoveNext();
            }

            return employeesWithPositions;
        }

        public abstract void Add(params EmployeeComponent[] employees);

        public abstract IEnumerator CreateIterator();
        public abstract string Accept(IVisitor visitor);
        public override string ToString()
        {
            return $"\t Name: {Name}. Position: {Position}. Salary: {Salary} Visitor functionality: {Accept(new EmployeeVisitor())}\n";
        }

    }
}
