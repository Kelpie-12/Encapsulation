using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AbstractGeometry
{
	abstract class Shape
	{
		protected static readonly int min_start_x = 10;
		protected static readonly int min_start_y = 10;
		protected static readonly int max_start_x = 800;
		protected static readonly int max_start_y = 600;
		protected static readonly int min_line_width = 3;
		protected static readonly int max_line_width = 33;
		protected static readonly int min_size = 50;
		protected static readonly int max_size = 800;


		int start_x;
		int start_y;
		int line_width;
		public Color Color { get; set; }
		public int Start_X 
		{
			get => start_x;
			set
			{
				if (value<min_start_x)
				{
					value = min_start_x;
				}
				if (value > max_start_x)
				{
					value = max_start_x;
				}
				start_x = value;
			}
		}
		public int Start_Y
		{
			get => start_y;
			set
			{
				if (value < min_start_y)
				{
					value = min_start_y;
				}
				if (value > max_start_y)
				{
					value = max_start_y;
				}
				start_y = value;
			}
		}
		public int Line_Width
		{
			get => line_width;
			set
			{
				if (value < min_start_x)
				{
					value = min_start_x;
				}
				if (value > max_start_x)
				{
					value = max_start_x;
				}
				line_width = value;
			}
		}
		public Shape(int start_x, int start_y, int line_width, Color color)
		{
			this.Start_X = start_x;
			this.Start_Y = start_y;
			this.Line_Width = line_width;
			Color = color;
		}
		//-----------------------------------------------//
		public abstract double Get_Area();
		public abstract double Get_Perimetr();
		public abstract void Draw(PaintEventArgs e);
		public virtual void Info(PaintEventArgs e)
		{
            Console.WriteLine(this);
			this.Draw(e);
        }
		public override string ToString()
		{
			string result = "";
			result += $"Area:\t{Get_Area()}\n";
			result += $"Perimetr:{Get_Perimetr()}\n";
			return result;
		}
	}
}
