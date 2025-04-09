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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    public override void UpdateEdges(T vertex, List<T> edges)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<KeyValuePair<T, List<T>>> GetEnumerator()
    {
         return _data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}