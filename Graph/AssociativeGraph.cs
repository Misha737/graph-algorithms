namespace Graph;

public class AssociativeGraph<T> : BaseGraph<T> where T : IEquatable<T> 
{
    private Dictionary<T, T> _data;

    public AssociativeGraph() : base()
    {
    }

    public override void Push(T vertex, List<T> edges)
    {
        throw new NotImplementedException();
    }
}