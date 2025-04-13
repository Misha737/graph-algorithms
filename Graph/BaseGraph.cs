namespace Graph;

public abstract class BaseGraph<T> where T: IEquatable<T>
{
    public int CountVertex { get; protected set; }
    public int CountEdges { get; protected set; }

    public void GenerateByRandom(int numberOfVertex, int density)
    {
        throw new NotImplementedException();
    }

    // To add a new vertex with edges and adding new edges for an existing vertex
    public abstract void AddVertex(T vertex, List<T>? edges = null);
    // To delete a existing vertex
    public abstract void DeleteVertex(T vertex);
    // To get edges by a some vertex. Null if a vertex doesn't exist
    public abstract List<T>? GetEdgesByVertex(T vertex);

    // To add relation between a vertex and an edge. Return false if edges don't exist
    public abstract bool AddEdge(T vertex, T edge);
    // To delete relation between a vertex and an edge
    public abstract void DeleteEdge(T vertex, T edge);

    // To replace edges for an existing vertex 
    public abstract void UpdateEdges(T vertex, List<T> edges);
    public abstract int GetVertexCount();

    public abstract IEnumerable<T> GetNeighbors(T u);
}