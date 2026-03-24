using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Bogus;
using System.Text;

namespace M006_Benchmarks;

/// <summary>
/// NuGet: BenchmarkDotNet
/// </summary>
internal class Program
{
	static void Main(string[] args)
	{
		//BenchmarkRunner.Run<PerformanceTests>();
		BenchmarkRunner.Run<StringBenchmarks>();
	}
}

[RankColumn]
[MemoryDiagnoser(false)]
[IterationCount(50)]
public class PerformanceTests
{
	//Benchmark 1: Comparison between different Linq-Methods
	//- Regular for-loop
	//- SQL-esque linq
	//- Method chains

	/// <summary>
	/// | Method                | Mean     | Error   | StdDev  | Rank | Allocated |
    /// |---------------------- |---------:|--------:|--------:|-----:|----------:|
    /// | BenchmarkForeach      | 302.6 us | 4.18 us | 8.35 us |    3 | 512.76 KB |
    /// | BenchmarkMethodChains | 200.0 us | 0.77 us | 1.41 us |    2 | 131.96 KB |
    /// | BenchmarkSQL          | 191.8 us | 0.71 us | 1.31 us |    1 | 129.03 KB |
	/// </summary>

	public List<Fahrzeug> Fahrzeuge { get; set; }

	[GlobalSetup]
	public void Setup()
	{
		//Fakes
		//Creating fake data for testing
		//-> NuGet: Bogus

		Faker<Fahrzeug> f = new Faker<Fahrzeug>();
		f.RuleFor(e => e.ID, e => e.IndexFaker);
		f.RuleFor(e => e.MaxV, e => e.Random.Int(150, 300));
		f.RuleFor(e => e.Marke, e => e.PickRandom<FahrzeugMarke>());
		Fahrzeuge = f.Generate(50000);
	}

	[Benchmark]
	public void BenchmarkForeach()
	{
		List<Fahrzeug> fzg = [];
		foreach (Fahrzeug f in Fahrzeuge)
			if (f.Marke == FahrzeugMarke.BMW)
				fzg.Add(f);
	}

	[Benchmark]
	public void BenchmarkMethodChains()
	{
		List<Fahrzeug> fzg = Fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW).ToList();
	}

	[Benchmark]
	public void BenchmarkSQL()
	{
		List<Fahrzeug> fzg = (from f in Fahrzeuge where f.Marke == FahrzeugMarke.BMW select f).ToList();
	}
}

[RankColumn]
[MemoryDiagnoser(false)]
[IterationCount(50)]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.SlowestToFastest)]
public class StringBenchmarks
{
	/// <summary>
	/// | Method            | Count  | Mean             | Error           | StdDev            | Median           | Rank | Allocated      |
    /// |------------------ |------- |-----------------:|----------------:|------------------:|-----------------:|-----:|---------------:|
    /// | StringPlus        | 100000 | 7,675,176.864 us | 689,177.9386 us | 1,392,173.5309 us | 8,345,860.950 us |    6 | 46777363.95 KB |
    /// | StringPlus        | 10000  |    19,293.470 us |     332.2403 us |       655.8100 us |    19,182.639 us |    5 |   370543.41 KB |
    /// | StringPlus        | 1000   |       159.720 us |       3.1497 us |         6.0684 us |       159.303 us |    3 |     2773.88 KB |
    /// | StringBuilderTest | 100000 |     2,381.413 us |      31.0683 us |        62.7596 us |     2,400.521 us |    4 |     5044.71 KB |
    /// | StringBuilderTest | 10000  |        85.885 us |       0.8669 us |         1.7313 us |        85.308 us |    2 |      458.59 KB |
    /// | StringBuilderTest | 1000   |         6.749 us |       0.0489 us |         0.0976 us |         6.761 us |    1 |       36.18 KB |
	/// </summary>


	[Params(1000, 10000, 100000)]
	public int Count {  get; set; }

	[Benchmark]
	public void StringPlus()
	{
		string result = string.Empty;
		for (int i = 0; i < Count; i++)
			result += i;
		string str = result;
	}

	[Benchmark]
	public void StringBuilderTest()
	{
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < Count; i++)
			sb.Append(i.ToString());
		string str = sb.ToString();
	}
}

public class Fahrzeug
{
	public int ID { get; set; }

	public int MaxV { get; set; }

	public FahrzeugMarke Marke { get; set; }
}

public enum FahrzeugMarke { Audi, BMW, VW }