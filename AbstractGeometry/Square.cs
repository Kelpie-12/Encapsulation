using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractGeometry
{
	internal class Square:Rectangle
	{
		//private int size;
		//public int Size
		//{
		//	get => size; 
		//	set => size = value < min_size ? min_size : value > max_size ? max_size : value;
		//}
		public Square(int start_x, int start_y, int line_width, Color color,int size) :base(size,size,start_x,start_y,line_width,color)
		{
			
		}
		public override string ToString()
		{
			string result = "";
			result += $"Size:\t{Height}\n";		
			result += base.ToString();
			return result;
		}

	}
}
