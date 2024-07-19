using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Random random = new Random(0);
			Console.WriteLine("Введите размер дерева");
			int n = Convert.ToInt32(Console.ReadLine());
			Tree tree = new Tree();
			for (int i = 0; i < n; i++)
			{
				tree.Insert(random.Next(100));
			}
			tree.Print();
			Console.WriteLine();
			Console.WriteLine($"Count_Element = {tree.Count_Element()}");
			Console.WriteLine();
			Console.WriteLine($"Sum_Tree = {tree.Sum_Tree()}");
			Console.WriteLine();
			Console.WriteLine($"Min_Value = {tree.Min_Value()}");
			Console.WriteLine();
			Console.WriteLine($"Max_Value = {tree.Max_Value()}");
			Console.WriteLine();
			Console.WriteLine($"AGV = {tree.AGV()}");
			Console.WriteLine();


		}
	}
}
