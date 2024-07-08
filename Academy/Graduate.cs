using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
	internal class Graduate:Student
	{
		private string subject;
		static public readonly int subject_width = 25;
		public string Subject
		{
			get { return subject; }
			set { subject = value; }
		}

		public Graduate (string last_name,string first_name,int age, string speciality, string groop, double reting, double attendance, string subject) : base(last_name, first_name, age, speciality, groop,reting,attendance)
		{
			Subject = subject;
			//Console.WriteLine($"G_Constructor {this.GetHashCode()}");
		}
		public Graduate(Student student,string subject) :base(student)
		{
			Subject = subject;
			//Console.WriteLine($"G_Constructor {this.GetHashCode()}");
		}
		~Graduate()
		{
			//Console.WriteLine($"G_Destructor {this.GetHashCode()}");
		}

		public override string ToString()
		{
			return base.ToString() + $"{subject.PadRight(subject_width)}";
		}


	}
}
