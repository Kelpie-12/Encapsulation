using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree
{
	internal class UniqurTree: Tree
	{
		protected override void Insert(int data, Element root)
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
			else if(data > root.data)
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
	}
}
