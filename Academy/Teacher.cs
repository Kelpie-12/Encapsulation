using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Academy
{
	internal class Teacher:Human
	{
		private string speciality;

		public string Speciality
		{
			get { return speciality; }
			set { speciality = value; }
		}
		private string experience;

		public string Experience
		{
			get { return experience; }
			set { experience = value; }
		}

		public Teacher(string last_name, string first_name, int age, string speciality, string experience) : base(last_name, first_name, age)
		{
			Speciality = speciality;		
			Experience = experience;
			Console.WriteLine($"T_Constructor {this.GetHashCode()}");
		}
		public Teacher(Human human,string speciality,string experience):base(human)
		{
			Speciality = speciality;
			Experience = experience;
			Console.WriteLine($"T_Constructor {this.GetHashCode()}");
		}
		~Teacher()
		{
			Console.WriteLine($"T_Destructor {this.GetHashCode()}");
		}

		public override string ToString()
		{
			return base.ToString() + $" {Speciality} {Experience} ";
		}
	}
}
