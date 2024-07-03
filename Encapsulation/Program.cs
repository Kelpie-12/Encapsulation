//#define classwork_01_07_24
using System;
using System.CodeDom;

namespace Encapsulation
{
	internal class Program
	{
		static void Main(string[] args)
		{
#if classwork_01_07_24

			Point a = new Point();
			a.ToString();
			//a.SetX(2);
			//a.SetY(13);
			//	Console.WriteLine($"a.x= {a.GetX()}\t a.y= {a.GetY()}");
			a.X = 22;
			a.Y = 32;
			Console.WriteLine($"a.x= {a.X}\t a.y= {a.Y}"); 
#endif
			Fraction a = new Fraction(5, 4);
			Fraction b = new Fraction(1,2, 4);
			Console.WriteLine($"a+b = {(a + b)}");
			Console.WriteLine($"a-b = {(a - b)}");
			Console.WriteLine($"a*b = {(a * b)}");
			Console.WriteLine($"a/b = {(a / b)}");
			Console.WriteLine($"a^2 = {(a ^ 2)}");
			Console.WriteLine($"a==b = {(a ==b)}");
			Console.WriteLine($"a!=b = {(a != b)}");
			Console.WriteLine($"a>b = {(a > b)}");
			Console.WriteLine($"a<b = {(a < b)}");
		}
	}
	class Fraction
	{
		public Fraction() { }
		public Fraction(int integer, int numerator, int denominator)
		{
			this.Numerator = numerator+(denominator*integer);
			this.Denominator = denominator;
		}
		public Fraction(int numerator, int denominator)
		{
			this.Numerator = numerator;
			this.Denominator = denominator;
		}
		private int integer;
		public int Integer
		{
			get { return integer; }
			set
			{
				if (value==0)
				{

				}
				else
				{
					integer = value;
				}			
			}
		}
		private int numerator;
		public int Numerator
		{
			get { return numerator; }
			set { numerator = value; }
		}
		private int denominator;
		public int Denominator
		{
			get { return denominator; }
			set
			{
				if (value == 0)
				{
                    Console.WriteLine("На ноль делить нельзя");
                }
				else
				{
					denominator = value;
				}
			}
		}
		public static Fraction operator +(Fraction a, Fraction b)
		{
			Fraction res = new Fraction();
			if (a.denominator==b.denominator)
			{
				res.denominator=a.denominator;
				res.numerator = a.numerator + b.numerator;
				return res;
			}
			res.denominator=b.denominator*a.denominator;
			res.Numerator = (a.numerator*b.denominator) + (b.numerator*a.denominator);
			return res;
		}
		public static Fraction operator -(Fraction a, Fraction b)
		{

			Fraction res = new Fraction();
			if (a.denominator == b.denominator)
			{
				res.denominator = a.denominator;
				res.numerator = a.numerator + b.numerator;
				return res;
			}
			res.denominator = b.denominator * a.denominator;
			res.Numerator = (a.numerator * b.denominator) - (b.numerator * a.denominator);
			return res;
		}
		public static Fraction operator *(Fraction a, Fraction b)
		{

			Fraction res = new Fraction();
			res.numerator=a.numerator*b.numerator;
			res.denominator=a.denominator*b.denominator;
			return res;
		}
		public static Fraction operator /(Fraction a, Fraction b)
		{
			Fraction res = new Fraction();
			res.numerator = a.numerator * b.denominator;
			res.denominator = a.denominator * b.numerator;
			return res;
		}
		public static Fraction operator ^(Fraction a, int power)
		{
			Fraction res = new Fraction();
			for (int i = 0; i < power; i++)
			{
				res = a * a;
			}
			return res;
		}
		public static bool operator ==(Fraction a, Fraction b)
		{		
			if ((a.denominator==b.denominator)&&(a.numerator==b.numerator))
			{
				return true;
			}			
			return false;
		}
		public static bool operator !=(Fraction a, Fraction b)
		{
			if ((a.denominator != b.denominator) )
			{
				return true;
			}
			return false;
		}
		public static bool operator >(Fraction a, Fraction b)
		{			
			if (a.denominator == b.denominator)
			{
				if (a.numerator>b.numerator)
				{
					return true;
				}
				else
				{
					return false;
				}				
			}
			int denom = a.denominator * b.denominator;
			a.numerator *= b.denominator;
			b.numerator *= a.denominator;
			a.denominator=b.denominator = denom;
			if (a.numerator > b.numerator)
			{
				return true;
			}
			else
			{
				return false;
			}		
		}
		public static bool operator <(Fraction a, Fraction b)
		{
			if (a.denominator == b.denominator)
			{
				if (a.numerator < b.numerator)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			int denom = a.denominator * b.denominator;
			a.numerator *= b.denominator;
			b.numerator *= a.denominator;
			a.denominator = b.denominator = denom;
			if (a.numerator < b.numerator)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public override string ToString()
		{
			int res = numerator / denominator , tmp = 0;
			if (res>0)
			{
				tmp = numerator - denominator * res;
				return res+" "+ tmp + "/" + denominator;
			}
			return numerator + "/" + denominator;
		}

	}
#if classwork_01_07_24
	struct Point
	{
		//double x;
		//double y;
		//public double X 
		//{
		//	get { return x; } 
		//	set {  this.x = value; } 
		//}
		//public double Y
		//{
		//	get { return y; }
		//	set { this.y = value; }
		//}
		//public double GetX()
		//{
		//	return x;
		//}
		//public double GetY()
		//{
		//	return y;
		//}
		//public void SetX(double x) { this.x= x; }
		//public void SetY(double y) { this.y = y; }
		public double X { get; set; }
		public double Y { get; set; }
		public double Z { get; set; }
	} 
#endif
}
