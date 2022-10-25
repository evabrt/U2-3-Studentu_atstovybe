using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_3_StudentuAtstovybe
{
    static class InOutUtils
    {
        /// <summary>
        /// Reads all students from the file
        /// </summary>
        /// <param name="filename">name of the file where's all the data</param>
        /// <returns>list of students</returns>
        public static StudentsRegister ReadStudents(string filename)
        {
            StudentsRegister Students = new StudentsRegister();
            string[] lines = File.ReadAllLines(filename, Encoding.UTF8);
            int year = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] Values = lines[i].Split(';');
                string surname = Values[0];
                string name = Values[1];
                DateTime birthDate = DateTime.Parse(Values[2]);
                int id = int.Parse(Values[3]);
                int course = int.Parse(Values[4]);
                long phoneNumber = int.Parse(Values[5]);

                Student student = new Student(year, surname, name, birthDate, id, course, phoneNumber, "");
                Students.Add(student);
            }
            return Students;
        }

        /// <summary>
        /// Prints students to the .txt file
        /// </summary>
        /// <param name="Students">list of students</param>
        public static void PrintStudentsToTxt(StudentsRegister Students, string filename)
        {
            List<string> lines = new List<string>();
            lines.Add(String.Format("{0}", Students.GetStudent(0).Year));
            lines.Add(new String('-', 110));
            lines.Add(String.Format("| {0, -12} | {1, -10} | {2, -12} | {3, -20} | {4, -7} | {5, -12} | {6, -7} | {7, -5} |", "Pavardė", "Vardas", "Gimimo data",
                "Studento pažym. nr.", "Kursas", "Telefono nr.", "Požymis", "Metai"));
            lines.Add(new String('-', 110));

            for (int i = 0; i < Students.Count(); i++)
            {
                lines.Add(Students.GetStudent(i).ToString());
            }
            lines.Add(new String('-', 110));

            File.AppendAllLines(filename, lines);
        }

        /// <summary>
        /// Prints students to console
        /// </summary>
        /// <param name="students">list of students</param>
        public static void PrintStudents(StudentsRegister students)
        {
            Console.WriteLine(new String('-', 110));
            Console.WriteLine("| {0, -12} | {1, -10} | {2, -12} | {3, -20} | {4, -7} | {5, -12} | {6, -7} | {7, -5} |", "Pavardė", "Vardas", "Gimimo data",
            "Studento pažym. nr.", "Kursas", "Telefono nr.", "Požymis", "Metai");
            Console.WriteLine(new String('-', 110));
            for (int i = 0; i < students.Count(); i++)
            {
                Console.WriteLine(students.GetStudent(i).ToString());
            }
            Console.WriteLine(new String('-', 110));
        }

        /// <summary>
        /// Prints members who have birthday on the one same month
        /// </summary>
        /// <param name="Students">list of students</param>
        /// <param name="month">student's birthday month</param>
        public static void PrintBirthdayMembersOfOneMonth(StudentsRegister Students, int month)
        {
            Console.WriteLine("Žmonės, švenčiantys gimtadienį šį mėnesį: ");
            Console.WriteLine(new String('-', 44));
            Console.WriteLine("| {0, -10} | {1, -12} | {2, -12} |", "Vardas", "Pavardė", "Gimimo diena");
            Console.WriteLine(new String('-', 44));
            for (int i = 0; i < Students.Count(); i++)
            {
                Student student = Students.GetStudent(i);
                if (student.BirthDate.Month == month)
                {
                    Console.WriteLine("| {0, -10} | {1, -12} | {2, -12} |", student.Name, student.Surname, student.BirthDate.Day);
                }
            }
            Console.WriteLine(new String('-', 44));
        }

        /// <summary>
        /// Prints members birthdays of all most popular months
        /// </summary>
        /// <param name="Students">list of students</param>
        /// <param name="months">array of counted birthdays</param>
        public static void PrintBirthdayMembersOfSeveralMonths(StudentsRegister Students, int[] months, int max)
        {
            Console.WriteLine("\nŽmonės, švenčiantys gimtadienį šiais mėnesiais: ");
            Console.WriteLine(new String('-', 44));
            Console.WriteLine("| {0, -10} | {1, -12} | {2, -12} |", "Vardas", "Pavardė", "Gimimo diena");
            Console.WriteLine(new String('-', 44));

            for (int i = 0; i < months.Length; i++)
            {
                for (int j = 0; j < Students.Count(); j++)
                {
                    Student student = Students.GetStudent(j);

                    if (student.BirthDate.Month == i && months[i] == max)
                    {
                        Console.WriteLine("| {0, -10} | {1, -12} | {2, -12} |", student.Name, student.Surname, student.BirthDate.Day);
                    }
                }
            }
            Console.WriteLine(new String('-', 44));

        }

        /// <summary>
        /// Check if there's new members and print them to CSV file
        /// </summary>
        /// <param name="fileName">name of the file</param>
        /// <param name="list">list of new members</param>
        public static void PrintCommonMembersToCSVFile(string fileName, StudentsRegister common)
        {
            string noMembers = "Studentų, priklausiusių visais metais nėra";
            if (common.Count() < 1)
                File.WriteAllText(fileName, noMembers, Encoding.UTF8);
            else
            {
                string[] lines = new string[common.Count()+1];
                lines[0] = String.Format("{0};{1};{2};{3};{4};{5};{6};{7}", "Pavardė", "Vardas", "Gimimo data", "Studento pažym. nr.", "Kursas", "Telefono nr.", "Požymis", "Metai");
                for (int i = 0; i < common.Count(); i++)
                {
                    Student student = common.GetStudent(i);

                    lines[i+1] = String.Format("{0};{1};{2};{3};{4};{5};{6};{7}", student.Surname, student.Name, student.BirthDate, student.ID, student.Course, student.PhoneNumber, student.NewMember, student.Year);
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
                
        }
    }
}
