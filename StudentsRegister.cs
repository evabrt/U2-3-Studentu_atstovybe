using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_3_StudentuAtstovybe
{
    internal class StudentsRegister
    {
        private List<Student> AllStudents;

        public StudentsRegister()
        {
            AllStudents = new List<Student>();
        }

        public StudentsRegister(List<Student> Students)
        {
            AllStudents = new List<Student>();
            foreach (Student s in Students)
                this.AllStudents.Add(s);
        }

        public void Add(Student student)
        {
            AllStudents.Add(student);
        }

        public Student GetStudent(int index)
        {
            return this.AllStudents[index];
        }

        public int Count()
        {
            return AllStudents.Count;
        }

        /// <summary>
        /// Finds what month has most birthdays
        /// </summary>
        /// <param name="students">Students</param>
        /// <returns>array of birthdays every month</returns>
        public int[] BirthdayMonth()
        {
            int[] month = new int[13];
            foreach (Student s in AllStudents)
            {
                month[s.BirthDate.Month] += 1;
            }
            return month;
        }

        /// <summary>
        /// Finds number of months with most birthdays
        /// </summary>
        /// <param name="month">array of birthdays every month</param>
        /// <param name="max">first month with most birthdays</param>
        /// <returns>number of month with most birthdays</returns>
        public int MaxBirthdaysMonths(int[] month)
        {
            int count = 0; //counts how many months with most birthdays
            foreach (int m in month)
            {
                if (m == month.Max())
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Returns month according to its index
        /// </summary>
        /// <param name="indexOfMonth">Index of months program needs to return</param>
        /// <returns>Name of the month</returns>
        public string Month(int indexOfMonth)
        {
            switch (indexOfMonth)
            {
                case 1:
                    return "Sausį";
                case 2:
                    return "Vasarį";
                case 3:
                    return "Kovą";
                case 4:
                    return "Balandį";
                case 5:
                    return "Gegužę";
                case 6:
                    return "Birželį";
                case 7:
                    return "Liepą";
                case 8:
                    return "Rugpjūtį";
                case 9:
                    return "Rugsėjį";
                case 10:
                    return "Spalį";
                case 11:
                    return "Lapkritį";
                case 12:
                    return "Gruodį";
                default:
                    return null;
            }
        }

        /// <summary>
        /// Prints month or months with most birthdays
        /// </summary>
        /// <param name="Students">list of students</param>
        public void PrintMonthWithMostBirthdays(int[] months, int howManyMonths, int numberOfMostBirthdays, int year)
        {
            if (howManyMonths == 1)
            {
                Console.WriteLine("\nDaugiausia gimtadienių {0} metais švenčiama: \n{1}", year,
                    Month(Array.IndexOf(months, numberOfMostBirthdays)));
            }
            else
            {
                Console.WriteLine("\nDaugiausia gimtadienių {0} metais švenčiama:", year);
                for (int i = 0; i < months.Length; i++)
                {
                    if (months[i] == numberOfMostBirthdays)
                    {
                        Console.WriteLine("{0}", Month(i));
                    }
                }
            }
        }

        /// <summary>
        /// Searches for the youngest member
        /// </summary>
        /// <param name="students">Register of students</param>
        /// <returns>youngest student</returns>
        public Student Youngest()
        {
            Student youngest = AllStudents[0];
            for (int i = 0; i < AllStudents.Count(); i++)
            {
                if (youngest < AllStudents[i])
                {
                    youngest = AllStudents[i];
                }
            }
            return youngest;
        }

        /// <summary>
        /// Finds all youngest members
        /// </summary>
        /// <param name="youngest">youngest student info</param>
        /// <returns>list of youngest members</returns>
        public StudentsRegister AllYoungestStudents (Student youngest)
        {
            StudentsRegister AllYoungest = new StudentsRegister();
            for(int i = 0; i < AllStudents.Count(); i++)
            {
                if (AllStudents[i] == youngest)
                {
                    AllYoungest.Add(AllStudents[i]);
                }
            }
            return AllYoungest;
        }

        /// <summary>
        /// Combines registers
        /// </summary>
        /// <param name="register">register</param>
        /// <param name="newRegister">main register</param>
        /// <returns>combined register</returns>
        public void AddRegister(StudentsRegister register)
        {
            for(int i = 0; i < register.Count(); i++)
            {
                AllStudents.Add(register.GetStudent(i));
            }            
        }

        /// <summary>
        /// Finds common members in both years
        /// </summary>
        /// <param name="earlier">list of earlier year students</param>
        /// <returns>list of common members</returns>
        public StudentsRegister FindCommonMembers(StudentsRegister earlier)
        {
            StudentsRegister commonMembers = new StudentsRegister();
            for(int i = 0; i < AllStudents.Count(); i++)
            {
                for (int j = 0; j < earlier.Count(); j++)
                {                    
                    if (AllStudents[i].Equals(earlier.GetStudent(j)))
                    {
                        commonMembers.Add(AllStudents[i]);
                    }
                }
            }
            return commonMembers;
        }
    }
}
