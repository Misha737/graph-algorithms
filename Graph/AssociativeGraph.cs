using System.Collections;

namespace Graph;

public class AssociativeGraph<T> : BaseGraph<T>, IEnumerable<KeyValuePair<T, List<T>>> where T : IEquatable<T>
{
    private Dictionary<T, List<T>> _data;
    public Dictionary<T, List<T>> Data => _data;

    public AssociativeGraph() : base()
    {
    }
    
    public AssociativeGraph(Dictionary<T, List<T>> associativeGraph) : base()
    {
        foreach (var edges in associativeGraph)
        {
            foreach (var edge in edges.Value)
            {
                if (!associativeGraph.ContainsKey(edge))
                    throw new ArgumentException("Graph is not valid");
            }
        }

        _data = associativeGraph;
    }

    public override void AddVertex(T vertex, List<T>? edges = null)
    {
        if (!_data.ContainsKey(vertex))
        {
            _data[vertex] = new List<T>();
        }
        
        if (edges != null)
        {
            _data[vertex].AddRange(edges);
        }
    }

    public override void DeleteVertex(T vertex)
    {
        if (!_data.ContainsKey(vertex))
            return;

        foreach (var pair in this)
        {
            pair.Value.Remove(vertex);
        }

        _data.Remove(vertex);
    }

    public override List<T>? GetEdgesByVertex(T vertex)
    {
        _data.TryGetValue(vertex, out var byVertex);
        return byVertex;
    }

    public override bool AddEdge(T vertex, T edge)
    {
        if (_data.ContainsKey(vertex) &&
            _data.ContainsKey(edge))
        {
            _data[vertex].Add(edge);
            CountEdges++;
            return true;
        }
        return false;
    }

    public override void DeleteEdge(T vertex, T edge)
    {
        if (_data.TryGetValue(vertex, out var byVertex))
            byVertex.Remove(edge);
    }

    public override void UpdateEdges(T vertex, List<T> edges)
    {
        _data[vertex] = edges;
    }

    public IEnumerator<KeyValuePair<T, List<T>>> GetEnumerator()
    {
         return _data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public MatrixGraph<T> ToMatrixGraph()
    {
        List<T> vertexes = _data.Keys.ToList();
        int[,] matrix = new int[_data.Count, _data.Count];
        foreach (var vertex in this)
        {
            foreach (var edge in vertex.Value)
            {
                matrix[vertexes.IndexOf(vertex.Key), vertexes.IndexOf(edge)] = 1;
            }
        }

        return new MatrixGraph<T>(matrix, vertexes);
    }
}