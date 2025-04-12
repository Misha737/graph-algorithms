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
        int index = _edges!.IndexOf(vertex);
        if (index == -1)
            return;
        _edges!.RemoveAt(index);
        _vertCount--;
        int[,] smallerMatrix = new int[_vertCount, _vertCount];
        for (int i = 0; i < _vertCount; i++)
        {
            if (i == index)
            {
                continue;
            }
            for (int j = 0; j < _vertCount; j++)
            {
                if (j == index)
                {
                    continue;
                }
                var iIndex = i < index ? i : i - 1;
                var jIndex = j < index ? j : j - 1;
                smallerMatrix[iIndex, jIndex] = _data[i, j];
            }
        }
        _data = smallerMatrix;
        
    }

    public override List<T>? GetEdgesByVertex(T vertex)
    {
        int index = _edges!.IndexOf(vertex);
        if (index == -1)
            return null;
        
        List<T> edges = new();
        for (int j = 0; j < _vertCount; j++)
        {
            if (_data[index, j] == 0)
                continue;
            edges.Add(_edges![j]);
        }
        return edges.ToList();
    }

    public override bool AddEdge(T vertex, T edge)
    {
        int row = _edges!.IndexOf(vertex);
        int col = _edges!.IndexOf(edge);
        if (row == -1 || col == -1)
            return false;
        _data[row, col] = 1;
        return true;
    }

    public override void DeleteEdge(T vertex, T edge)
    {
        int row = _edges!.IndexOf(vertex);
        int col = _edges!.IndexOf(edge);
        if (row == -1 || col == -1)
            return;
        _data[row, col] = 0;
    }

    public override void UpdateEdges(T vertex, List<T> edges)
    {

        int vertIndex = edges.IndexOf(vertex);
        if (vertIndex == -1)
            return;
        for (int i = 0; i < _vertCount; i++)
            _data[vertIndex, i] = edges.Contains(_edges![i]) ? 1 : 0;
    }

    public void AddEdges(T vertex, List<T>? edges)
    {
        if (edges == null)
            return;

        int vertIndex = edges.IndexOf(vertex);
        if (vertIndex == -1)
            return;
        foreach (var edge in edges)
            _data[vertIndex, _edges!.IndexOf(edge)] = 1;
    }
}