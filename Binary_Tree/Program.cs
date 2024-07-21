#define tree_base_check
using System;


namespace Binary_Tree
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Random random = new Random(0);
			//Console.WriteLine("Введите размер дерева");
			//int n = Convert.ToInt32(Console.ReadLine());
#if tree_base_check
			UniqurTree tree = new UniqurTree() { 36,55,11,22,100,100,100,10,20,30, };
			//for (int i = 0; i < n; i++)
			//{
			//	tree.Insert(random.Next(100));
			//}
					
			tree.Print_Tree();
			Console.WriteLine();
			//tree.Clear();
			int b = Convert.ToInt32(Console.ReadLine());
			tree.Erase(b);
			Console.WriteLine($"Depth = {tree.Depth()}");
			tree.Print_Tree();
			//Console.WriteLine();
			//Console.WriteLine($"Count_Element = {tree.Count_Element()}");
			//Console.WriteLine();
			//Console.WriteLine($"Sum_Tree = {tree.Sum_Tree()}");
			//Console.WriteLine();
			//Console.WriteLine($"Min_Value = {tree.Min_Value()}");
			//Console.WriteLine();
			//Console.WriteLine($"Max_Value = {tree.Max_Value()}");
			//Console.WriteLine();
			//Console.WriteLine($"AGV = {tree.AGV()}");
			//Console.WriteLine(); 
#endif


		}
	}
}
