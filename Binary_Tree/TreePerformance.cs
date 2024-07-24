using System;
using System.Diagnostics;

namespace Binary_Tree
{
	internal class TreePerformance
	{
		public delegate int Method_Int();
		public delegate double Method_Double();
		public static void Measure(string message, Method_Int method)
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			int value = method();
			sw.Stop();
            Console.WriteLine($"{message}: {value}, вычисленно за {sw.Elapsed.TotalMilliseconds} ms");
        }
		public static void Measure(string message, Method_Double method)
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			double value = method();
			sw.Stop();
			Console.WriteLine($"{message}: {value}, вычисленно за {sw.Elapsed.TotalMilliseconds} ms");
		}
		public TreePerformance() { }

	}
}
