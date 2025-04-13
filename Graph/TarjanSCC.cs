namespace Graph
{
    public class TarjanSCC
    {
        public static List<List<int>> Run(MatrixGraph<int> graph)
        {
            int n = graph.Matrix.GetLength(0);

            int[] disc = new int[n], low = new int[n];
            bool[] inStack = new bool[n];
            Stack<int> stack = new Stack<int>();
            List<List<int>> scc = new List<List<int>>();
            int time = 0;

            void DFS(int u)
            {
                disc[u] = low[u] = ++time;
                stack.Push(u);
                inStack[u] = true;

                var neighbors = graph.GetMatrixNeighbors(u);
                foreach (int v in neighbors)
                {
                    if (disc[v] == 0)
                    {
                        DFS(v);
                        low[u] = Math.Min(low[u], low[v]);
                    }
                    else if (inStack[v]) 
                        low[u] = Math.Min(low[u], disc[v]);
                }

                if (disc[u] == low[u])
                {
                    List<int> component = new List<int>();
                    int w;
                    do
                    {
                        w = stack.Pop();
                        inStack[w] = false;
                        component.Add(w);
                    } while (w != u);

                    scc.Add(component); 
                }
            }

            for (int i = 0; i < n; i++)
                if (disc[i] == 0) 
                    DFS(i);

            return scc;
        }
    }
}
