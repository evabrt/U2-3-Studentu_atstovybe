using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_3_StudentuAtstovybe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Reads all of students data ant stores it in register
            StudentsRegister register = InOutUtils.ReadStudents(@"Students.csv");
            // Reads earlier students and puts it in register
            StudentsRegister earlierRegister = InOutUtils.ReadStudents(@"EarlierStudents.csv");
            // Prints all students data
            File.Delete("Duomenys.txt");
            InOutUtils.PrintStudentsToTxt(register, "Duomenys.txt");
            InOutUtils.PrintStudentsToTxt(earlierRegister, "Duomenys.txt");


            // All about printing this years most common students birthdays

            int[] months = register.BirthdayMonth(); // Array of months with number of birthdays as a value
            int howManyMonths = register.MaxBirthdaysMonths(months); // Counts how many months with most birthdays
            int numberOfMostBirthdays = months.Max(); // Number with the value of most birthdays in month
            int today = DateTime.Today.Year;
            // Prints month (or months) with most birthdays
            register.PrintMonthWithMostBirthdays(months, howManyMonths, numberOfMostBirthdays, today);
            // Takes value of how many months has most birthdays
            int count = register.MaxBirthdaysMonths(months);
            // Takes number of first (or only) month with most birthdays
            int month = Array.IndexOf(register.BirthdayMonth(), register.BirthdayMonth().Max());
            // Checks if there's one or more months with most birthdays            
            if (count == 1)
                InOutUtils.PrintBirthdayMembersOfOneMonth(register, month);
            else
                InOutUtils.PrintBirthdayMembersOfSeveralMonths(register, register.BirthdayMonth(), numberOfMostBirthdays);


            // All about printing last years most common students birthdays

            int[] earlierMonths = earlierRegister.BirthdayMonth(); 
            int MonthsEarlier = earlierRegister.MaxBirthdaysMonths(earlierMonths);
            int numberOfMostBirthdaysEarlier = earlierMonths.Max(); 
            earlierRegister.PrintMonthWithMostBirthdays(earlierMonths, MonthsEarlier, numberOfMostBirthdaysEarlier, earlierRegister.GetStudent(0).Year);
            int countEarlier = earlierRegister.MaxBirthdaysMonths(earlierMonths);
            int monthEarlier = Array.IndexOf(earlierRegister.BirthdayMonth(), earlierRegister.BirthdayMonth().Max());
            if (countEarlier == 1)
                InOutUtils.PrintBirthdayMembersOfOneMonth(earlierRegister, monthEarlier);
            else
                InOutUtils.PrintBirthdayMembersOfSeveralMonths(earlierRegister, earlierMonths, numberOfMostBirthdaysEarlier);

            // Combining this year and last year registers
            StudentsRegister combinedRegister = new StudentsRegister();
            combinedRegister.AddRegister(register);
            combinedRegister.AddRegister(earlierRegister);

            //Printing youngest member(members) from both years
            Student youngest = combinedRegister.Youngest();
            StudentsRegister AllYoungest = combinedRegister.AllYoungestStudents(youngest);
            if (AllYoungest.Count() == 1)
            {
                Console.WriteLine("\nJauniausias studentas: ");
                InOutUtils.PrintStudents(AllYoungest);
            }
            else
            {
                Console.WriteLine("\nJauniausi studentai: ");
                InOutUtils.PrintStudents(AllYoungest);                
            }

            // Prints common members to .csv file
            StudentsRegister commonMembers = register.FindCommonMembers(earlierRegister);
            InOutUtils.PrintCommonMembersToCSVFile("Seniai.csv", commonMembers);

            Console.ReadKey();
        }
    }
}
