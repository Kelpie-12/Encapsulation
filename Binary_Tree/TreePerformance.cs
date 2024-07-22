using System;
using System.Diagnostics;

namespace Binary_Tree
{
	internal class TreePerformance
	{
		public delegate int Method();
		public static void Measure(string message, Method method)
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			int value = method();
			sw.Stop();
            Console.WriteLine($"{message}: {value}, вычисленно за {sw.Elapsed.TotalMilliseconds} ms");


        }
		public TreePerformance() { }

	}
}
