using System;
using System.Collections.Generic;
using StudentModels;
using AppService;

namespace StudentManagementSystem
{
    internal class Program
    {
        static StudentService service = new StudentService();

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
            Student student = new Student();

            Console.Write("\nFirst Name: ");
            student.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            student.LastName = Console.ReadLine();

            Console.Write("Student Number: ");
            student.StudentNumber = Console.ReadLine();

            Console.Write("Contact Number: ");
            student.ContactNumber = Console.ReadLine();

            Console.Write("Address: ");
            student.Address = Console.ReadLine();

            
            student.Status = "Active";

            service.EnrollStudent(student);

            Console.WriteLine("\nStudent Enrolled Successfully!");
            MainMenu();
        }

        static void ViewStudents()
        {
            List<Student> students = service.ViewStudents();
            Console.WriteLine("\n----- STUDENT LIST -----");

            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
            }
            else
            {
                foreach (Student student in students)
                {
                    Console.WriteLine("Name: " + student.FirstName + " " + student.LastName);
                    Console.WriteLine("Student Number: " + student.StudentNumber);
                    Console.WriteLine("Contact Number: " + student.ContactNumber);
                    Console.WriteLine("Address: " + student.Address);
                    Console.WriteLine("Status: " + student.Status);
                }
            }

            MainMenu();
        }

        static void UpdateStudent()
        {
            Student student = new Student();

            Console.Write("Enter Student Number: ");
            student.StudentNumber = Console.ReadLine();

            Console.Write("New First Name: ");
            student.FirstName = Console.ReadLine();

            Console.Write("New Last Name: ");
            student.LastName = Console.ReadLine();

            Console.Write("New Contact Number: ");
            student.ContactNumber = Console.ReadLine();

            Console.Write("New Address: ");
            student.Address = Console.ReadLine();

            service.UpdateStudent(student);


            if (service.StudentExists(student.StudentNumber))
            {
                Console.WriteLine("Student Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Student Not Found.");
            }

            MainMenu();
        }

        static void DeleteStudent()
        {

            Console.Write("Enter Student Number: ");
            string studentNumber = Console.ReadLine();

            service.DeleteStudent(studentNumber);


            if (service.StudentExists(studentNumber))
            {
                Console.WriteLine("Student Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Student Not Found.");
            }

            MainMenu();
        }

        static void DeactivateStudent()
        {
            Console.Write("Enter Student Number: ");
            string studentNumber = Console.ReadLine();

            service.DeactivateStudent(studentNumber);


            if (service.StudentExists(studentNumber))
            {
                Console.WriteLine("Student Deactivated.");
            }
            else
            {
                Console.WriteLine("Student Not Found.");
            }

            MainMenu();
        }

        static void StudentLeave()
        {
            Console.Write("Enter Student Number: ");
            string studentNumber = Console.ReadLine();

            service.StudentLeave(studentNumber);


            if (service.StudentExists(studentNumber))
            {
                Console.WriteLine("Student Leave Approved.");
            }
            else
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