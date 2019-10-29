namespace BIL
{
    public interface IVisitable
    {
        string Accept(IVisitor visitor);
    }
}
