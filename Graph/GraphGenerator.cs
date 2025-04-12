namespace Graph;

public class GraphGenerator
{
    private Random _rand = new();
    public int? VertexCount;
    public int? DensityCount;

    public GraphGenerator(int vertex, int density)
    {
        VertexCount = vertex;
        DensityCount = density;
    }

    public MatrixGraph<int>? GenerateMatrixGraph(int vertexCount, int densityCount)
    {
        if (vertexCount <= 0 || densityCount <= 0)
            return null;
        var graph = new MatrixGraph<int>();
        List<int> vertexes = new();
        int edgesDensity = vertexCount*vertexCount*(densityCount/100);
        if (edgesDensity <= 0)
            return null;
        for (int i = 0; i < vertexCount; i++)
        {
            vertexes.Add(i);
        }
        graph.SetEmptyMatrix(vertexes);

        for (int i = 0; i < vertexCount; i++)
        {
            for (int j = 0; j < vertexCount; j++)
            {
                graph.Matrix[i, j] = _rand.NextDouble() < edgesDensity ? 1 : 0;
            }
        }
        
        return graph;
    }
}