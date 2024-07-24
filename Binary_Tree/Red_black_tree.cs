using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Binary_Tree
{
	internal class Red_black_tree
	{

		public class Element
		{
			public int data;
			public Element p_left;
			public Element p_right;
			// red ==> true, black ==> false
			public bool color;
			public Element(int data, bool color, Element p_left = null, Element p_right = null)
			{
				this.data = data;
				this.p_left = p_left;
				this.p_right = p_right;
				this.color = color;
				//Console.WriteLine($"EConstructor:\t{GetHashCode()}");
			}
			~Element()
			{
				//Console.WriteLine($"EDestructor:\t{GetHashCode()}");
			}
		}
		public Element root;
		public Element Create_Element(int data, bool color)
		{
			Element e = new Element(data, color);			
			return e;
		}
		Element Rotate_Left(ref Element e)
		{
			Element child = e.p_right;
			Element child_left = child.p_left;
			child.p_left = e;
			e.p_right = child_left;
			return child;
		}
		Element Rotate_Right(ref Element e)
		{
			Element child = e.p_left;
			Element child_right = child.p_right;
			child.p_right = e;
			e.p_left = child_right;
			return child;
		}
		private bool isRed(ref Element e)
		{
			if (e == null)
				return false;
			e.color = true;
			return e.color;
		}
		void Swap_Colors(ref Element e1, ref Element e2)
		{
			bool temp = e1.color;
			e1.color = e2.color;
			e2.color = temp;
		}
		public void Insert(int data)
		{
			Insert(ref root, data);
		}
		public Element Insert(ref Element root, int data)
		{			
			if (root == null)
				return Create_Element(data, false);

			if (data < root.data)
				root.p_left = Insert(ref root.p_left, data);

			else if (data > root.data)
				root.p_right = Insert(ref root.p_right, data);

			//else
			//	return root;
			
			if (isRed(ref root.p_right) &&
			   !isRed(ref root.p_left))
			{				
				root = Rotate_Left(ref root);				
				Swap_Colors(ref root, ref root.p_left);
			}
			
			if (isRed(ref root.p_left) &&
				isRed(ref root.p_left.p_left))
			{				
				root = Rotate_Right(ref root);
				Swap_Colors(ref root, ref root.p_right);
			}
			
			if (isRed(ref root.p_left) && isRed(ref root.p_right))
			{				
				root.color = !root.color;
				root.p_left.color = false;
				root.p_right.color = false;
			}
			return root;
		}
		
		private void Inorder(ref Element root)
		{
			if (root != null)
			{
				Inorder(ref root.p_left);
				Console.WriteLine($"Data -> {root.data} {root.color}");
				Inorder(ref root.p_right);
			}
		}
		public void Print()
		{ 
			Inorder(ref root);
		}
	}
}

