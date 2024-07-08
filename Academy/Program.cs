//#define inheritance_1
//#define inheritance_2
//#define save_to_file
#define load_from_file
using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections.Generic;
namespace Academy
{
	internal class Program
	{
		static readonly string delimiter = "\n-------------------------------------------------\n";
		static Program() 
		{
			Directory.SetCurrentDirectory("..\\..");
		}
		//static Human[] Load(string filename)
		//{
		//	StreamReader read = new StreamReader(filename);
		//	string tmp;
		//	string reader = " ";
		//	int count = 0;
		//	while (reader != null)
		//	{
		//		reader = read.ReadLine();
		//		//Console.WriteLine(reader);
		//		count++;
		//	}
		//	read.Close();
		//	count--;
		//	Human[] result = new Human[count];			
		//	int i = 0;
		//	read = new StreamReader(filename);
		//	reader = " ";
		//	while (count != 0)
		//	{
		//		reader = read.ReadLine();

		//		int index_start = 12;
		//		tmp = reader.Substring(0, index_start);
		//		tmp = tmp.Replace(" ", "");

		//		string last_name = reader.Substring(index_start, Human.last_name_width);
		//		index_start += Human.last_name_width;
		//		last_name = last_name.Replace(" ", "");

		//		string first_name = reader.Substring(index_start, Human.first_name_width);
		//		index_start += Human.first_name_width;
		//		first_name = first_name.Replace(" ", "");

		//		string age = reader.Substring(index_start, Human.age_width);
		//		index_start += Human.age_width;
		//		age = age.Replace(" ", "");

		//		if (tmp == "Academy.Student:")
		//		{
		//			string speciality = reader.Substring(index_start, Student.specialiity_width);
		//			index_start += Student.specialiity_width;
		//			speciality = speciality.Replace(" ", "");

		//			string groop = reader.Substring(index_start, Student.group_width);
		//			index_start += Student.group_width;
		//			groop = groop.Replace(" ", "");

		//			string reting = reader.Substring(index_start, Student.rating_width);
		//			index_start += Student.rating_width;
		//			reting = reting.Replace(" ", "");

		//			string attendance = reader.Substring(index_start, Student.attendance_width);
		//			//index_start += Student.attendance_width;
		//			//index_start = 20;
		//			attendance = attendance.Replace(" ", "");
		//			result[i] = new Student(last_name, first_name, Convert.ToInt32(age), speciality, groop, Convert.ToDouble(reting), Convert.ToDouble(attendance));
		//		}
		//		else if (tmp == "Academy.Teacher:")
		//		{
		//			string speciality = reader.Substring(index_start, Teacher.SPECIALITY_WIDTH);
		//			index_start += Teacher.SPECIALITY_WIDTH;
		//			speciality = speciality.Replace(" ", "");

		//			string experience = reader.Substring(index_start, Teacher.EXPERIENCE_WIDTH);
		//			experience = experience.Replace(" ", "");
		//			result[i] = new Teacher(last_name, first_name, Convert.ToInt32(age), speciality, experience);
		//		}
		//		else if (tmp == "Academy.Graduate:")
		//		{
		//			string speciality = reader.Substring(index_start, Student.specialiity_width);
		//			index_start += Student.specialiity_width;
		//			speciality = speciality.Replace(" ", "");

		//			string groop = reader.Substring(index_start, Student.group_width);
		//			index_start += Student.group_width;
		//			groop = groop.Replace(" ", "");

		//			string reting = reader.Substring(index_start, Student.rating_width);
		//			index_start += Student.rating_width;
		//			reting = reting.Replace(" ", "");

		//			string attendance = reader.Substring(index_start, Student.attendance_width);
		//			index_start += Student.attendance_width;
		//			//index_start = 20;
		//			attendance = attendance.Replace(" ", "");

		//			string subject = reader.Substring(index_start, Graduate.subject_width);
		//			subject = subject.Replace(" ", "");
		//			result[i] = new Graduate(last_name, first_name, Convert.ToInt32(age), speciality, groop, Convert.ToDouble(reting), Convert.ToDouble(attendance), subject);
		//		}
		//		else if (tmp == "Academy.Human:")
		//		{
		//			result[i] = new Human(last_name, first_name, Convert.ToInt32(age));
		//		}
		//		i++;
		//		count--;
		//	}

		//	read.Close();
		//	return result;
		//}
		static Human[] Load(string filename)
		{
			//Directory.SetCurrentDirectory("..\\..");
			List<Human> group = new List<Human>();
			if (File.Exists(filename))
			{
				StreamReader sr = new StreamReader(filename);
				while (!sr.EndOfStream)
				{
					string buffer = sr.ReadLine();
					// Console.WriteLine(buffer);
					if (buffer.Length == 0)
						continue;
					string[] values = buffer.Split(':', ',', ';');
					group.Add(HumanFactory(values.First()));
					group.Last().Init(values);
				}
				sr.Close(); 
			}
			else
			{
                Console.WriteLine("Error: File not found");
            }

			return group.ToArray();
		}
		static Human HumanFactory(string type)
		{
			Human human = null;
			switch (type)
			{
				case "Human":
					human = new Human("", "", 0);
					break;
				case "Teacher":
					human = new Teacher("", "", 0, "", "");
					break;
				case "Student":
					human = new Student("", "", 0, "", "", 0, 0);
					break;
				case "Graduate":
					human = new Graduate("", "", 0, "", "", 0, 0, "");
					break;
				default:
					break;
			}
			return human;
		}
		static void Save(ref Human[] group, string name_file)
		{
			//Directory.SetCurrentDirectory("..\\..");
			StreamWriter writer = new StreamWriter(name_file);
			for (int i = 0; i < group.Length; i++)
			{
				writer.WriteLine(group[i].ToStringFile());
			}
			System.Diagnostics.Process.Start("notepad", name_file);
			writer.Close();
		}
		static void Print(ref Human[] group)
		{
			for (int i = 0; i < group.Length; i++)
			{
				Console.WriteLine(group[i]);
				Console.WriteLine(delimiter);
			}
		}
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
#if save_to_file
			Human[] group = new Human[]
				{
				new Human("John", "Doe", 20),
				new Human("Elon", "Musk", 55),
				new Student("Jane", "Doe", 22, "Math", "223", 95, 97),
				new Teacher("W", "W", 50, "math", "25"),
				new Graduate("Schrader", "Hank", 40, "Criminalistic", "Obn", 85, 75, "How meet your mother"),
				};
			Print(ref group);
			Save(ref group, "group.csv");
			Human[] group_test = Load("group.csv"); 
#endif
			//Print(ref group_test);	
#if load_from_file
			Human[] group2 = Load("group.csv");
			Print(ref group2); 
#endif

		}
	}
}

