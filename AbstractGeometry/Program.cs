using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AbstractGeometry
{
	internal class Program
	{
		static void Main(string[] args)
		{
			
			IntPtr hwnd = GetConsoleWindow();
			Graphics graphics=  Graphics.FromHwnd(hwnd);
			System.Drawing.Rectangle window_rectangle = new System.Drawing.Rectangle(Console.WindowLeft, Console.WindowTop, Console.WindowWidth, Console.WindowHeight);
			PaintEventArgs e = new PaintEventArgs(graphics, window_rectangle);
			
			Rectangle a = new Rectangle(50, 100, 300, 0, 10, Color.Red);
			//a.Info(e);

			Circle b =new Circle(300,180, 50,10,Color.White);			
			//b.Info(e);

			Point[] points_triangle = new Point[3];
			Random rand = new Random();
			for (int i = 0; i < points_triangle.Length; i++)
			{			
				points_triangle[i].X = rand.Next(300,500);
				points_triangle[i].Y = rand.Next(300, 500);
			}
			Triangle c = new Triangle(ref points_triangle, 10, Color.Green);
			c.Info(e);

			Square d = new Square(200, 100, 15, Color.White, 100);
			//d.Info(e);


		}
		[DllImport("kernel32.dll")]
		public static extern bool GetStdHandle(int nStdHandle);
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetConsoleWindow();
		[DllImport("kernel32.dll")]
		public static extern IntPtr GetDC(IntPtr hwnd);
	}
}
