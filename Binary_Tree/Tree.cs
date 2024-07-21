#define IEnumerable_IEnumerator
using System;
using System.Collections;
using System.Collections.Generic;


namespace Binary_Tree
{
	internal class Tree:IEnumerable,IEnumerator
	{

#if IEnumerable_IEnumerator
		public IEnumerator GetEnumerator()
		{
			return this;
		}
		public bool MoveNext()
		{
			if (root == null)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		public void Reset()
		{
			root = null;
		}
		public object Current
		{
			get { return root.data; }
		} 
#endif
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
		public void Add(int data)
		{
			Insert(data);
		}
		public int Depth()
		{
			return Depth(ref root);
		}
		private int Depth(ref Element root)
		{
			if (root == null)
			{
				return 0;
			}
			int left_depth = Depth(ref root.p_left) + 1;
			int right_depth = Depth(ref root.p_right) + 1;
			if (left_depth > right_depth)
			{
				return left_depth;
			}
			else
			{
				return right_depth;
			}
		}
		public void Erase(int data)
		{
			Erase(ref root, data);
		}
		private void Erase(ref Element root, int data)
		{

			if (root == null)
			{
				return;
			}
			if (data == root.data)
			{
				if (root.p_left == null && root.p_right == null)
				{
					root = null;
				}
				else
				{
					if (Count_Element(root.p_left) > Count_Element(root.p_right))
					{
						root.data = Max_Value(root.p_left);
						Erase(ref root.p_left, Max_Value(root.p_left));
					}
					else
					{
						root.data = Min_Value(root.p_right);
						Erase(ref root.p_right, Max_Value(root.p_right));
					}
				}
			}
			if (root != null)
			{
				Erase(ref root.p_left, data);
				Erase(ref root.p_right, data);
			}
		}
		public void Clear()
		{
			Clear(ref root);
		}
		private void Clear(ref Element root)
		{
			if (root == null)
			{
				//Console.WriteLine("Clear");
				return;
			}
			Clear(ref root.p_left);
			Clear(ref root.p_left);
			root = null;
		}
		protected virtual void Insert(int data, Element root)
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
		private void Print_Tree(Element root, int depth)
		{
			if (root == null)
			{
				return;
			}
			int count = 2;
			depth += 2;
			Print_Tree(root.p_right, depth);
			for (int i = count; i < depth; i++)
			{
				Console.Write("  ");
			}
			Console.Write($"{root.data}\n");
			Print_Tree(root.p_left, depth);
			//if (root == null)
			//{               
			//             return;
			//}

			//for (int i = 0; i < depth; i++)
			//{
			//	Console.Write("|  ");
			//}
			//Console.Write($"\b\b--{root.data}\n");
			//Print_Tree(root.p_left, depth + 1);
			//Print_Tree(root.p_right, depth + 1);

		}
		public void Print_Tree()
		{
			Print_Tree(root, 0);
		}

	}
}
