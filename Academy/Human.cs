using System;


namespace Academy
{
	internal class Human
	{
		static readonly int last_name_width = 15;
		static readonly int first_name_width = 15;
		static readonly int age_width = 5;
		string last_name;
		string first_name;
		int age;
		public string Last_Name
		{
			get => last_name;
			set { last_name = value; }
		}
		public string First_Name
		{
			get => first_name;
			set { first_name = value; }
		}
		public int Age
		{
			get => age;
			set { age = value; }
		}
		public Human(string last_name, string first_name, int age)
		{
			this.Last_Name = last_name;
			this.First_Name = first_name;
			this.Age = age;
			Console.WriteLine($"H_Constructor {this.GetHashCode()}");
		}
		public Human(Human other)
		{
			this.First_Name= other.First_Name;
			this.Age = other.Age;
			this.Last_Name=other.Last_Name;
			Console.WriteLine($"H_Copy_Constructor {this.GetHashCode()}");
		}
		~Human()
		{
			Console.WriteLine($"H_Destructor {this.GetHashCode()}");
		}
		public override string ToString()
		{
			return  $"{GetType()}: ".PadRight(20) + $" {Last_Name.PadRight(last_name_width)} {First_Name.PadRight(first_name_width)} {Age.ToString().PadRight(age_width)}";
		}
	}
}
