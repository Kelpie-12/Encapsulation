using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace AbstractGeometry
{
	internal class Triangle : Shape
	{
		private Point[] points;
		public Point[] Points
		{
			get { return points; }
			set
			{
				for (int i = 0; i < 3; i++)
				{
					if (value[i].X < min_start_x)
					{
						value[i].X = min_start_x;
					}
					else if (value[i].X > max_start_x)
					{
						value[i].X = max_start_x;
					}
					else
					{
						this.points[i].X = value[i].X;
					}

					if (value[i].Y < min_start_y)
					{
						value[i].Y = min_start_y;
					}
					else if (value[i].Y > max_start_y)
					{
						value[i].Y = max_start_y;
					}
					else
					{
						this.points[i].Y = value[i].Y;
					}
				}
			}
		}
		
		public Triangle(ref Point[] points2, int line_width, Color color) : base(points2[0].X, points2[0].Y, line_width, color)
		{
			points = new Point[3] { new Point(points2[0].X, points2[0].Y), new Point(points2[1].X, points2[1].Y), new Point(points2[2].X, points2[2].Y) };
		}
		private double get_side_a()
		{
			int AB = points[0].X - points[1].X;
			int BC = points[0].Y - points[1].Y;
			return Math.Sqrt((AB * AB) + (BC * BC));
		}
		private double get_side_b()
		{
			int AB = points[0].X - points[2].X;
			int BC = points[0].Y - points[2].Y;
			return Math.Sqrt((AB * AB) + (BC * BC));
		}
		private double get_side_c()
		{
			int AB = points[1].X - points[2].X;
			int BC = points[1].Y - points[2].Y;
			return Math.Sqrt((AB * AB) + (BC * BC));
		}
		public override double Get_Area()
		{
			double p = 0.5 * Get_Perimetr();

			return Math.Sqrt(p * (p - get_side_a()) * (p - get_side_b()) * p - get_side_c());
		}
		public override double Get_Perimetr()
		{
			return get_side_a() + get_side_b() + get_side_c();
		}
		public override string ToString()
		{
			string result = "";
			result += $"Side a:\t{get_side_a()}\n";
			result += $"Side b:\t{get_side_b()}\n";
			result += $"Side C:\t{get_side_c()}\n";
			result += base.ToString();
			return result;
		}
		public override void Draw(PaintEventArgs e)
		{
			e.Graphics.DrawPolygon(new Pen(Color, Line_Width), points);
		}
	}
}
