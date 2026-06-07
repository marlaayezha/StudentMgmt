using System;
using System.Collections.Generic;
using System.Linq;
using StudentModels;

namespace DataService
{
    public class StudentMgmtInMemoryData : IStudentMgmtDataService
    {
        public List<Student> students = new List<Student>();

        public StudentMgmtInMemoryData()
        {
            Student student1 = new Student
            {
                FirstName = "Marla",
                LastName = "Miranda",
                StudentNumber = "2026-0001",
                ContactNumber = "09123456789",
                Address = "Binan City",
                Status = "Active"
            };

            Student student2 = new Student
            {
                FirstName = "Mary",
                LastName = "Freo",
                StudentNumber = "2026-0002",
                ContactNumber = "09987654321",
                Address = "Bacoor City",
                Status = "Active"
            };

            Student student3 = new Student
            {
                FirstName = "Yuki",
                LastName = "San",
                StudentNumber = "2026-0003",
                ContactNumber = "09111222333",
                Address = "Tokyo, Japan",
                Status = "Active"
            };

            students.Add(student1);
            students.Add(student2);
            students.Add(student3);
        }

        public void Add(Student student)
        {
            students.Add(student);
        }

        public Student GetByStudentNumber(string studentNumber)
        {
            return students.FirstOrDefault(s => s.StudentNumber == studentNumber);
        }

        public bool StudentExists(string studentNumber)
        {
            return students.Where(x => x.StudentNumber == studentNumber).Any();
        }

        public void Update(Student student)
        {
            var existing = GetByStudentNumber(student.StudentNumber);

            if (existing != null)
            {
                existing.FirstName = student.FirstName;
                existing.LastName = student.LastName;
                existing.ContactNumber = student.ContactNumber;
                existing.Address = student.Address;
                existing.Status = student.Status;
            }
        }

        public void Delete(string studentNumber)
        {
            var student = GetByStudentNumber(studentNumber);

            if (student != null)
            {
                students.Remove(student);
            }
        }

        public void Deactivate(string studentNumber)
        {
            var student = GetByStudentNumber(studentNumber);

            if (student != null)
            {
                student.Status = "Deactivated";
            }
        }

        public void Leave(string studentNumber)
        {
            var student = GetByStudentNumber(studentNumber);

            if (student != null)
            {
                student.Status = "On Leave";
            }
        }

        public List<Student> GetStudents()
        {
            return students;
        }
    }
}
