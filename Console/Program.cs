using BIL;
using BIL.Output;

namespace Console
{
    class Program
    {
        private static readonly string[] POSITIONS =
        {
            "director",
            "manager",
            "team group",
            "Another one manager"
        };

        static void Main(string[] args)
        {
            IOutput stringOutput = new StringOutput();
            EmployeeComponent director = new Employee("Director", Program.POSITIONS[0], 20);
            EmployeeComponent manager = new Employee("Manager of storing", POSITIONS[1], 15);
            EmployeeComponent manager2 = new Employee("Manager of marketing", POSITIONS[1], 12);
            EmployeeComponent x = new SubEmployee("X", POSITIONS[2], 10);
            EmployeeComponent y = new SubEmployee("Y", POSITIONS[2], 10);
            EmployeeComponent a = new SubEmployee("A", POSITIONS[2], 10);
            EmployeeComponent b = new SubEmployee("B", POSITIONS[2], 10);
            EmployeeComponent c = new Employee("Another one manager", POSITIONS[1], 10);
            EmployeeComponent d = new SubEmployee("D", POSITIONS[2], 10);
            director.Add(manager, manager2);
            manager.Add(x, y, c);
            manager2.Add(a, b);
            c.Add(d);
            Company company = new Company(director, stringOutput);
            System.Console.WriteLine("----------");
            company.PrintHierarchy();
            System.Console.WriteLine("----------");
            company.PrintAllByPosition("manager");
            System.Console.WriteLine("----------");
            company.PrintAllWithHighestSalaryAndHigherThan(9);
            System.Console.WriteLine("----------");
            company.PrintAllWithParent(manager);
            System.Console.WriteLine("----------");
            company.PrintBackwards();
            System.Console.WriteLine("----------");
            System.Console.ReadKey();
        }
    }
}
