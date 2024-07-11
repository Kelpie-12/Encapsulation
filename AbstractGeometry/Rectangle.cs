using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstractGeometry
{
	internal class Rectangle:Shape
	{
		double width;
		double height;
		public double Width
		{
			get=>width;
			set => width = value < min_size ? min_size: value>max_size?max_size:value;
		}

		public double Height
		{
			get => height;
			set => height = value < min_size ? min_size : value > max_size ? max_size : value;
		}
		public Rectangle(double width, double height, int start_x, int start_y, int line_width, Color color):base(start_x,start_y,line_width,color)
		{
			Width = width;
			Height = height;
		}
		public override double Get_Area()
		{
			return Width* Height;
		}
		public override double Get_Perimetr()
		{
			return (Width + Height)*2;
		}
		public override void Draw(PaintEventArgs e)
		{
			//e.Graphics.DrawEllipse(new Pen(Color, Line_Width), (int)Start_X, (int)Start_Y, (float)Width, (float)Height);
			e.Graphics.DrawRectangle(new Pen(Color, Line_Width), Start_X, Start_Y, (float)Width, (float)Height);
		}
		public override string ToString()
		{
			string result = "";
			result += $"Width:\t{Width}\n";
			result += $"Height:\t{Height}\n";
			result += base.ToString();
			return result;
		}
	}
}
