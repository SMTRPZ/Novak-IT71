using System.Collections;
using System.Collections.Generic;

namespace BIL
{
    public sealed class Employee : EmployeeComponent, IVisitable
    {
        private ISubordinateBehaviour _behaviour;
        public List<EmployeeComponent> Employees { get; set; }

        public Employee(string name, string position, int salary) : base(name, position, salary)
        {
            _behaviour = new ManySubordinatesBehaviour();
            Employees = new List<EmployeeComponent>();
        }
        public override void Add(params EmployeeComponent[] employees)
        {
            _behaviour.Add(Employees, employees);
        }

        public override IEnumerator CreateIterator()
        {
            return Employees.GetEnumerator();
        }

        public override string Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
