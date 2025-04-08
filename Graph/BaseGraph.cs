namespace Graph;

public abstract class BaseGraph<T> where T: IEquatable<T>
{
    public int CountVertex { get; protected set; }
    public int CountEdges { get; protected set; }

    // To add a new vertex with edges and adding new edges for an existing vertex
    public abstract void Push(T vertex, List<T> edges);
    // To delete a existing vertex
    public abstract void Delete(T vertex);
    // To replace edges for an existing vertex 
    public abstract void Update(T vertex, List<T> edges);
    // To get edges by a some vertex. Null if a vertex doesn't exist
    public abstract List<T>? GetEdges(T vertex);
}