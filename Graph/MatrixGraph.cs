namespace Graph;

public class MatrixGraph<T> : BaseGraph<T> where T : IEquatable<T>
{
    private int[,] _data;
    public int[,] Matrix => _data;
    private List<T>? _edges;
    private int _vertCount;

    public MatrixGraph() : base()
    {
        
    }
    public MatrixGraph(int[,] matrix, List<T> vertexes) : base()
    {
        _data = matrix;
        _edges = vertexes;
    }

    public override void AddVertex(T vertex, List<T>? edges = null)
    {
        if (edges == null)
        {
            return;
        }

        if (edges.Contains(vertex))
        {
            AddEdges(vertex, edges);
            return;
        }

        _edges!.Add(vertex);
        _vertCount++;
        int[,] newMatrix = new int[_vertCount, _vertCount];
        for (int i = 0; i < _vertCount; i++)
        {
            for (int j = 0; j < _vertCount; j++)
            {
                if (i == _vertCount - 1 || j == _vertCount - 1)
                {
                    newMatrix[i, j] = 0;
                    continue;
                }

                newMatrix[i, j] = _data[i, j];
            }
        }

        _data = newMatrix;

        AddEdges(vertex, edges);

    }

    public override void DeleteVertex(T vertex)
    {
        throw new NotImplementedException();
    }

    public override List<T>? GetEdgesByVertex(T vertex)
    {
        throw new NotImplementedException();
    }

    public override bool AddEdge(T vertex, T edge)
    {
        throw new NotImplementedException();
    }

    public override void DeleteEdge(T vertex, T edge)
    {
        throw new NotImplementedException();
    }

    public override void UpdateEdges(T vertex, List<T> edges)
    {
        throw new NotImplementedException();
    }

    public void AddEdges(T vertex, List<T>? edges)
    {
        if (edges == null)
        {
            return;
        }

        int vertIndex = edges.IndexOf(vertex);
        foreach (var edge in edges)
            _data[vertIndex, _edges!.IndexOf(edge)] = 1;
    }
}