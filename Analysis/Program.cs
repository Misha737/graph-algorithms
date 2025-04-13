using Graph;

for (int n = 20; n <= 500; n += 20)
{
    for (int density = 10; density <= 90; density += 20)
    {
        var gen = new GraphGenerator();
        var g = gen.GenerateMatrixGraph(n, density);

        var sw = System.Diagnostics.Stopwatch.StartNew();
        TarjanSCC.Run(g);
        sw.Stop();

        Console.WriteLine($"n = {n}, density = {density}, time = {sw.ElapsedMilliseconds} ms");
    }
}