using StudentDataService;
using StudentModels;
using System;
using System.Collections.Generic;

namespace DataService
{
    public class StudentMgmtDataService
    {
        IStudentMgmtDataService dataService = new StudentJsonData();

        public void Add(Student student)
        {
            dataService.Add(student);
        }

        public Student? GetByStudentNumber(string studentNumber)
        {
            return dataService.GetByStudentNumber(studentNumber);
        }

        public bool StudentExists(string studentNumber)
        {
            return dataService.StudentExists(studentNumber);
        }

        public void Update(Student student)
        {
            dataService.Update(student);
        }

        public void Delete(string studentNumber)
        {
            dataService.Delete(studentNumber);
        }

        public void Deactivate(string studentNumber)
        {
            dataService.Deactivate(studentNumber);
        }

        public void Leave(string studentNumber)
        {
            dataService.Leave(studentNumber);
        }

        public List<Student> GetStudents()
        {
            return dataService.GetStudents();
        }
    }
}