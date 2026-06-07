using System;
using System.Collections.Generic;
using StudentModels;

namespace DataService
{
    public interface IStudentMgmtDataService
    {
        void Add(Student student);
        Student? GetByStudentNumber(string studentNumber);
        bool StudentExists(string studentNumber);
        void Update(Student student);
        void Delete(string studentNumber);
        void Deactivate(string studentNumber);
        void Leave(string studentNumber);
        List<Student> GetStudents();
    }
}
