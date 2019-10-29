namespace BIL
{
    public interface IVisitor
    {
        string Visit(Employee employee);
        string Visit(SubEmployee subEmployee);
    }
}
