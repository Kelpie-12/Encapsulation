using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree
{
	internal class Tree
	{
		public class Element
		{
			public int data;
			public Element p_left;
			public Element p_right;
			public Element(int data, Element p_left = null, Element p_right = null)
			{
				this.data = data;
				this.p_left = p_left;
				this.p_right = p_right;
				//Console.WriteLine($"EConstructor:\t{GetHashCode()}");
			}
			~Element()
			{
				//Console.WriteLine($"EDestructor:\t{GetHashCode()}");
			}
		}
		public Element root;
		public Tree()
		{

			//Console.WriteLine($"TConstructor:\t{GetHashCode()}");
		}
		~Tree()
		{
			//Console.WriteLine($"TDestructor:\t{GetHashCode()}");
		}
		private void Insert(int data, Element root)
		{
			if (this.root == null)
			{
				this.root = new Element(data);
			}
			if (root == null)
			{
				return;
			}
			if (data < root.data)
			{
				if (root.p_left == null)
				{
					root.p_left = new Element(data);
				}
				else
				{
					Insert(data, root.p_left);
				}
			}
			else
			{
				if (root.p_right == null)
				{
					root.p_right = new Element(data);
				}
				else
				{
					Insert(data, root.p_right);
				}
			}
		}
		public void Insert(int data)
		{
			Insert(data, this.root);
		}
		private int Count_Element(Element root)
		{
			if (root == null)
				return 0;
			else
				return Count_Element(root.p_left) + Count_Element(root.p_right) + 1;
		}
		public int Count_Element()
		{ 
			return Count_Element(this.root); 
		}
		private int Sum_Tree(Element root)
		{
			if (root == null)
				return 0;
			else
				return root.data + Sum_Tree(root.p_left) + Sum_Tree(root.p_right);
		}
		public int Sum_Tree()
		{
			return Sum_Tree(this.root);
		}
		private int Max_Value(Element root)
		{

			if (root.p_right == null)
				return root.data;
			else
				return Max_Value(root.p_right);
		}
		public int Max_Value()
		{
			return Max_Value(this.root);
		}
		private int Min_Value(Element root)
		{
			if (root.p_left == null)
				return root.data;
			else
				return Min_Value(root.p_left);
		}
		public int Min_Value()
		{
			return Min_Value(this.root);
		}

		private double AGV(Element root)
		{
			return (double)Sum_Tree(root) / Count_Element(root);
		}
		public double AGV()
		{
			return AGV(this.root);
		}
		private void Print(Element root)
		{
			if (root == null)
			{
				return;
			}
			Print(root.p_left);
			Console.Write($"{root.data}\t");
			Print(root.p_right);
		}
		public void Print()
		{
			Print(root);
		}
	}
}
