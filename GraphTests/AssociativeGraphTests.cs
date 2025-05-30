﻿using Graph;

namespace GraphTests;

public class AssociativeGraphTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CorrectGraph_InstanceGraph()
    {
        Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
        dict[4] = new List<int> { 5, 6 };
        dict[5] = new List<int>();
        dict[6] = new List<int>();

        AssociativeGraph<int> graph = new AssociativeGraph<int>(dict);
        Assert.That(graph.Data, Is.EquivalentTo(dict));
    }
    [Test]
    
    public void DoesNotCorrectGraph_InstanceGraph_CatchException()
    {
        Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
        dict[4] = new List<int> { 5, 6 };
        dict[5] = new List<int>();
        
        Assert.Throws<ArgumentException>(() =>
        {
            var associativeGraph = new AssociativeGraph<int>(dict);
        });
    }

    [Test]
    public void Graph_ForeachEdges_OrderedList()
    {
        Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
        dict[4] = new List<int> { 5, 6 };
        dict[5] = new List<int>();
        dict[6] = new List<int>{4};
        AssociativeGraph<int> graph = new AssociativeGraph<int>(dict);

        List<(int, int[]?)> edges = new List<(int, int[]?)>();
        foreach (var edge in graph)
        {
            edges.Add((edge.Key, edge.Value.ToArray()));
        }

        Assert.That(edges, Is.EquivalentTo(new List<(int, int[]?)>()
        {
            (4, new[] { 5, 6 }),
            (5, new List<int>().ToArray()),
            (6, new[] { 4 })
        }));
    }
    
    [Test]
    public void AssociativeGraph_AddEdge_TrueAndDictionaryRight()
    {
        Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
        dict[4] = new List<int> { 5, 6 };
        dict[5] = new List<int>();
        dict[6] = new List<int>(){4};
        AssociativeGraph<int> graph = new AssociativeGraph<int>(dict);

        bool result = graph.AddEdge(5, 6);

        Assert.That(result, Is.EqualTo(true));
        Assert.That(graph.Data[5], Is.EquivalentTo(new int[]{6}));
    }
    
    [Test]
    public void AssociativeGraph_AddEdge_False()
    {
        Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
        dict[4] = new List<int> { 5, 6 };
        dict[5] = new List<int>();
        dict[6] = new List<int>(){4};
        AssociativeGraph<int> graph = new AssociativeGraph<int>(dict);

        bool result = graph.AddEdge(5, 7);

        Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void Graph_DeleteVertex_DictAreEqual()
    {
        Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
        dict[4] = new List<int> { 5, 6 };
        dict[5] = new List<int>(){6};
        dict[6] = new List<int>(){4};
        AssociativeGraph<int> graph = new AssociativeGraph<int>(dict);
        
        graph.DeleteVertex(6);

        Assert.That(graph.Data[4].ToArray(), Is.EquivalentTo(new []{5}));
        Assert.That(graph.Data[5].ToArray(), Is.EquivalentTo(Enumerable.Empty<int>()));
        Assert.That(graph.Data.ContainsKey(6), Is.EqualTo(false));
    }
    
    [Test]
    public void Graph_GetEdgesByVertex_ListOfVertexes()
    {
        Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
        dict[4] = new List<int> { 5, 6 };
        dict[5] = new List<int>(){6};
        dict[6] = new List<int>(){4};
        AssociativeGraph<int> graph = new AssociativeGraph<int>(dict);

        int[] edges = graph.GetEdgesByVertex(4)!.ToArray();
        Assert.That(edges, Is.EquivalentTo(new []{5, 6}));
    }
    
    [Test]
    public void Graph_GetEdgesByNonExistVertex_ListOfVertexes()
    {
        Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
        dict[4] = new List<int> { 5, 6 };
        dict[5] = new List<int>(){6};
        dict[6] = new List<int>(){4};
        AssociativeGraph<int> graph = new AssociativeGraph<int>(dict);

        List<int>? edges = graph.GetEdgesByVertex(7);
        Assert.That(edges, Is.Null);
    }

    [Test]
    public void AssociativeGraph_ToMatrixGraph_MatrixAreEqual()
    {
        int[,] expectedMatrix = new int[3,3];
        expectedMatrix[0, 1] = 1;
        expectedMatrix[0, 2] = 1;
        expectedMatrix[1, 2] = 1;
        expectedMatrix[2, 0] = 1;
        Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
        dict[4] = new List<int> { 5, 6 };
        dict[5] = new List<int>(){6};
        dict[6] = new List<int>(){4};
        AssociativeGraph<int> graph = new AssociativeGraph<int>(dict);

        MatrixGraph<int> matrixGraph = graph.ToMatrixGraph();
        int[,] matrix = matrixGraph.Matrix;
        
        Assert.That(matrix, Is.EquivalentTo(expectedMatrix));
    }
}