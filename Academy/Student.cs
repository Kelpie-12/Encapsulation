using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Academy
{
	internal class Student : Human
	{
		static public readonly int specialiity_width = 20;
		static public readonly int group_width = 8;
		static	public readonly int rating_width = 8;
		static public readonly int attendance_width = 8;
		private string speciality;
		public string Speciality
		{
			get { return speciality; }
			set { speciality = value; }
		}

		private string group;
		public string Group
		{
			get { return group; }
			set { group = value; }
		}

		private double rating;
		public double Rating
		{
			get { return rating; }
			set { rating = value; }
		}

		private double attendance;

		public double Attendance
		{
			get { return attendance; }
			set { attendance = value; }
		}

		public Student(string last_name, string first_name, int age, string speciality, string groop, double reting, double attendance) : base(last_name, first_name, age)
		{
			Attendance = attendance;
			Rating = reting;
			Group = groop;
			Speciality = speciality;
			//Console.WriteLine($"S_Constructor {this.GetHashCode()}");
		}
		public Student(Human human, string speciality, string groop, double reting, double attendance) : base(human)
		{
			Attendance = attendance;
			Rating = reting;
			Group = groop;
			Speciality = speciality;
		}
		public Student(Student other):base(other)
		{
			Attendance = other.Attendance;
			Rating = other.Rating;
			Group = other.Group;
			Speciality = other.Speciality;
			//Console.WriteLine($"S_Copy_Constructor {this.GetHashCode()}");
		}
		~Student()
		{
			//Console.WriteLine($"S_Destructor {this.GetHashCode()}");
		}

		public override string ToString()
		{
			return base.ToString() + $"{Speciality.PadRight(specialiity_width)}{Group.PadRight(group_width)}{Attendance.ToString().PadRight(attendance_width)}{Rating.ToString().PadRight(rating_width)}";
		}
		public override string ToStringFile()
		{
			return base.ToStringFile().Replace(";",",") + $"{Speciality},{Group},{Attendance.ToString()},{Rating.ToString()};";
		}

	}
}
