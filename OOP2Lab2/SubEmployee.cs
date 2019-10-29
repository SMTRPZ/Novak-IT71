using System.Collections;

namespace BIL
{
    public sealed class SubEmployee : EmployeeComponent, IVisitable
    {
        private ISubordinateBehaviour _behaviour;
        public SubEmployee(string name, string position, int salary) : base(name, position, salary)
        {
            _behaviour = new NoOneSubordinatesBehaviour();
        }

        public override IEnumerator CreateIterator()
        {
            return new NullIterator();
        }

        public override string Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }

        public override void Add(params EmployeeComponent[] employees)
        {
            _behaviour.Add(null, employees);
        }
    }
}
