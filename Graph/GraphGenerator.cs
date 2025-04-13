namespace Graph;

public class GraphGenerator
{
    private Random _rand = new();

    public MatrixGraph<int>? GenerateMatrixGraph(int vertexCount, int densityCount)
    {
        if (vertexCount <= 0 || densityCount < 0)
            return null;

        var graph = new MatrixGraph<int>();
        List<int> vertexes = new List<int>();

        for (int i = 0; i < vertexCount; i++)
            vertexes.Add(i);

        graph.SetEmptyMatrix(vertexes);

        double probability = densityCount / 100.0;

        for (int i = 0; i < vertexCount; i++)
            for (int j = 0; j < vertexCount; j++)
                if (i != j && _rand.NextDouble() < probability)
                    graph.Matrix[i, j] = 1;

        return graph;
    }
}