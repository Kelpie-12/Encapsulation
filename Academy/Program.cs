//#define inheritance_1
//#define inheritance_2
using System;
using System.IO;
using System.Diagnostics;
namespace Academy
{
	internal class Program
	{
		static readonly string delimiter = "\n-------------------------------------------------\n";
		static void Main(string[] args)
		{
#if inheritance_1
			Human human = new Human("John", "Doe", 20);
			Console.WriteLine(human);

			Student student = new Student("Jane", "Doe", 22, "Math", "223", 95, 97);
			Console.WriteLine(student);

			Teacher teacher = new Teacher("W", "W", 50, "math", "25");
			Console.WriteLine(teacher);

			Graduate graduate = new Graduate("Schrader", "Hank", 40, "Criminalistic", "Obn", 85, 75, "Ch");
			Console.WriteLine(graduate); 
#endif
#if inheritance_2
			Human human = new Human("John", "Doe", 20);
			Student student = new Student(human, "Theft", "Vice", 95, 100);			
			Console.WriteLine(student);
			Console.WriteLine(delimiter);
			Graduate graduate = new Graduate(student, "How i meet your mather");
			Console.WriteLine(graduate);
			Console.WriteLine(delimiter);
			Teacher teacher = new Teacher(human, "test", "20");
			Console.WriteLine(teacher);
			Console.WriteLine(delimiter);
#endif
			Human[] group = new Human[]
			{
				new Student("Jane", "Doe", 22, "Math", "223", 95, 97),
				new Teacher("W", "W", 50, "math", "25"),
				new Graduate("Schrader", "Hank", 40, "Criminalistic", "Obn", 85, 75, "Ch"),
			};
			for (int i = 0; i < group.Length; i++)
			{			
				Console.WriteLine(group[i]);
				Console.WriteLine(delimiter);
			}
			StreamWriter writer = new StreamWriter("group.txt");
			for (int i = 0; i < group.Length; i++)
			{
				writer.WriteLine(group[i]);
			}
			writer.Close();

			string cmd = "group.txt";
			System.Diagnostics.Process.Start("notepad",cmd);

		}
	}
}

