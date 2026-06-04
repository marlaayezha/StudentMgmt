using System;
using System.Collections.Generic;

namespace StudentManagementSystem
{
    internal class Program
    {
        static List<string> firstNames = new List<string>();
        static List<string> lastNames = new List<string>();
        static List<string> studentNumbers = new List<string>();
        static List<string> contactNumbers = new List<string>();
        static List<string> addresses = new List<string>();
        static List<string> status = new List<string>();

        static void Main(string[] args)
        {
            Console.WriteLine("STUDENT MANAGEMENT SYSTEM");

            MainMenu();
        }

        static void MainMenu()
        {
            Console.WriteLine("\n----- MAIN MENU -----");
            Console.WriteLine("1. View Students");
            Console.WriteLine("2. Enroll Student");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Deactivate Student");
            Console.WriteLine("6. Student Leave");
            Console.WriteLine("7. View Rules");
            Console.WriteLine("8. Exit");

            Console.Write("Choose Option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ViewStudents();
                    break;

                case "2":
                    EnrollStudent();
                    break;

                case "3":
                    UpdateStudent();
                    break;

                case "4":
                    DeleteStudent();
                    break;

                case "5":
                    DeactivateStudent();
                    break;

                case "6":
                    StudentLeave();
                    break;

                case "7":
                    ViewRules();
                    break;

                case "8":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid Option.");
                    MainMenu();
                    break;
            }
        }

        static void EnrollStudent()
        {
            Console.Write("\nFirst Name: ");
            string fName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lName = Console.ReadLine();

            Console.Write("Student Number: ");
            string studNum = Console.ReadLine();

            Console.Write("Contact Number: ");
            string conNum = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            firstNames.Add(fName);
            lastNames.Add(lName);
            studentNumbers.Add(studNum);
            contactNumbers.Add(conNum);
            addresses.Add(address);
            status.Add("Active");

            Console.WriteLine("\nStudent Enrolled Successfully!");
            MainMenu();
        }

        static void ViewStudents()
        {
            Console.WriteLine("\n----- STUDENT LIST -----");

            if (firstNames.Count == 0)
            {
                Console.WriteLine("No students found.");
            }
            else
            {
                for (int i = 0; i < firstNames.Count; i++)
                {
                    Console.WriteLine("\nStudent #" + (i + 1));
                    Console.WriteLine("Name: " + firstNames[i] + " " + lastNames[i]);
                    Console.WriteLine("Student Number: " + studentNumbers[i]);
                    Console.WriteLine("Contact Number: " + contactNumbers[i]);
                    Console.WriteLine("Address: " + addresses[i]);
                    Console.WriteLine("Status: " + status[i]);
                }
            }

            MainMenu();
        }

        static void UpdateStudent()
        {
            Console.Write("Enter Student Number: ");
            string studNum = Console.ReadLine();

            bool found = false;

            for (int i = 0; i < studentNumbers.Count; i++)
            {
                if (studentNumbers[i] == studNum)
                {
                    Console.Write("First Name: ");
                    firstNames[i] = Console.ReadLine();

                    Console.Write("Last Name: ");
                    lastNames[i] = Console.ReadLine();

                    Console.Write("Contact Number: ");
                    contactNumbers[i] = Console.ReadLine();

                    Console.Write("Address: ");
                    addresses[i] = Console.ReadLine();

                    Console.WriteLine("Student Updated Successfully!");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Student Not Found.");
            }

            MainMenu();
        }

        static void DeleteStudent()
        {
            Console.Write("Enter Student Number: ");
            string studNum = Console.ReadLine();

            bool found = false;

            for (int i = 0; i < studentNumbers.Count; i++)
            {
                if (studentNumbers[i] == studNum)
                {
                    firstNames.RemoveAt(i);
                    lastNames.RemoveAt(i);
                    studentNumbers.RemoveAt(i);
                    contactNumbers.RemoveAt(i);
                    addresses.RemoveAt(i);
                    status.RemoveAt(i);

                    Console.WriteLine("Student Deleted Successfully!");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Student Not Found.");
            }

            MainMenu();
        }

        static void DeactivateStudent()
        {
            Console.Write("Enter Student Number: ");
            string studNum = Console.ReadLine();

            bool found = false;

            for (int i = 0; i < studentNumbers.Count; i++)
            {
                if (studentNumbers[i] == studNum)
                {
                    status[i] = "Deactivated";
                    Console.WriteLine("Student Deactivated.");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Student Not Found.");
            }

            MainMenu();
        }

        static void StudentLeave()
        {
            Console.Write("Enter Student Number: ");
            string studNum = Console.ReadLine();

            bool found = false;

            for (int i = 0; i < studentNumbers.Count; i++)
            {
                if (studentNumbers[i] == studNum)
                {
                    status[i] = "On Leave";
                    Console.WriteLine("Student Leave Approved.");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Student Not Found.");
            }

            MainMenu();
        }

        static void ViewRules()
        {
            Console.WriteLine("\n----- SCHOOL RULES -----");
            Console.WriteLine("1. Attend classes regularly.");
            Console.WriteLine("2. Respect teachers and classmates.");
            Console.WriteLine("3. Wear proper uniform.");
            Console.WriteLine("4. Submit projects on time.");
            Console.WriteLine("5. No cheating.");

            MainMenu();
        }
    }
}