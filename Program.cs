using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


class Program
{
    public static void Main()
    {

#if RELEASE

        var summary = BenchmarkRunner.Run(typeof(BenchmarkTest).Assembly);

#else 
        var benchmarkTest = new BenchmarkTest();

        Console.WriteLine($"Foreach start. {DateTime.Now}");

        benchmarkTest.SetOrderLinesWithForeach();

        Console.WriteLine($"Foreach end. {DateTime.Now}");

        Console.WriteLine($"Linq start. {DateTime.Now}");

        benchmarkTest.SetOrderLinesWithLinq();

        Console.WriteLine($"Linq end. {DateTime.Now}");

        Console.ReadLine();
#endif
    }
}

[MemoryDiagnoser]
public class BenchmarkTest
{
    List<Order> orders = new List<Order>();

    List<OrderLine> orderLines = new List<OrderLine>();

    public int Count { get; set; } = 100_000;

    public BenchmarkTest()
    {
        for (int i = 1; i < Count; i++)
        {
            orders.Add(new()
            {
                Id = i,
                Address = $"Baku {i}",
                ClientId = i * 2
            });
        }

        for (int i = 1; i < Count * 2; i++)
        {
            orderLines.Add(new()
            {
                Id = i,
                OrderId = i <= Count ? i : i - Count,
                ItemId = i * 2
            });
        }
    }

    [Benchmark]
    public void SetOrderLinesWithForeach()
    {
        foreach (var order in orders)
        {
            order.Lines = orderLines.Where(x => x.OrderId == order.Id).ToList();
        }
    }

    [Benchmark]
    public void SetOrderLinesWithLinq()
    {
        var query = from order in orders
                    join orderLine in orderLines on order.Id equals orderLine.OrderId
                    group orderLine by order into grouping
                    select grouping.Key.SetLines(grouping.ToList());

        // It for to call the SetLines method for each line
        _ = query.ToList();
    }
}