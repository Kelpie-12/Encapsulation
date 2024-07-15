using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstractGeometry
{
	internal class Circle:Shape,IHaveDiameter
	{
		public Circle(int x, int y, int radius, int line_width, Color color):base(x,y,line_width,color) 
		{
			Radius = radius;
		}
		private float radius;
		public float Radius
		{
			get { return radius; }
			set => radius = value < min_size ? min_size : value > max_size ? max_size : value;
		}
		public override void Draw(PaintEventArgs e)
		{
			e.Graphics.DrawEllipse(new Pen(Color, Line_Width), (int)Start_X, (int)Start_Y, (float)Radius*2, (float)Radius*2);			
		}
		public override double Get_Area()
		{
			return 3.14* Radius*Radius;
		}
		public override double Get_Perimetr()
		{
			return 2 * 3.14 * Radius;
		}
		public double Get_Diameter()
		{
			return radius * 2;
		}
		public override string ToString()
		{
			string result = "";
			result += $"Radius:\t{Radius}\n";
			result += $"Diameter:{Get_Diameter()}\n";
			result += base.ToString();
			return result;
		}
	}
}
