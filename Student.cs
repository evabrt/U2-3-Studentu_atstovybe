using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_3_StudentuAtstovybe
{
    internal class Student
    {
        public int Year { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public long ID { get; set; }
        public int Course { get; set; }
        public long PhoneNumber { get; set; }
        public string NewMember { get; set; }
        public Student(int year,  string surname, string name, DateTime birthDate, long id, int course, long phoneNumber, string newMember)
        {
            this.Year = year;
            this.Surname = surname;
            this.Name = name;
            this.BirthDate = birthDate.Date;
            this.ID = id;
            this.Course = course;
            this.PhoneNumber = phoneNumber;
            this.NewMember = newMember;
        }
        /// <summary>
        /// Overrides method ToString
        /// </summary>
        /// <returns>String with student info</returns>
        public override string ToString()
        {
            return string.Format("| {0, -12} | {1, -10} | {2, -12:yyy-MM-dd} | {3, -20} | {4, -7} | {5, -12} | {6, -7} | {7, -5} |", Surname, Name, BirthDate, ID, Course, PhoneNumber, NewMember, Year);
        }

        /// <summary>
        /// Overrides operator == and checks if students birthdays match
        /// </summary>
        /// <param name="student1">first student</param>
        /// <param name="student2">second student</param>
        /// <returns>bool</returns>
        public static bool operator == (Student student1, Student student2)
        {
            return student1.BirthDate == student2.BirthDate;
        }

        /// <summary>
        /// Overrides operator != and checks if students birthdays don't match
        /// </summary>
        /// <param name="student1"></param>
        /// <param name="student2"></param>
        /// <returns></returns>
        public static bool operator != (Student student1, Student student2)
        {
            return student1.BirthDate != student2.BirthDate;
        }

        /// <summary>
        /// Overrides method equals and checks if students are the same by their student ID
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool</returns>
        public override bool Equals(object obj)
        {
            Student student = obj as Student;
            return student.ID == ID;
        }

        /// <summary>
        /// Overrides GetHashCode method
        /// </summary>
        /// <returns>bool</returns>
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        /// <summary>
        /// Overrides operator > and checks which student is older
        /// </summary>
        /// <param name="student1">first student</param>
        /// <param name="student2">second student</param>
        /// <returns>bool</returns>
        public static bool operator > (Student student1, Student student2)
        {
            return student1.BirthDate > student2.BirthDate;
        }
        /// <summary>
        /// Overrides operator > and checks which student is older
        /// </summary>
        /// <param name="student1">first student</param>
        /// <param name="student2">second student</param>
        /// <returns>bool</returns>
        public static bool operator < (Student student1, Student student2)
        {
            return student1.BirthDate < student2.BirthDate;
        }
    }
}
