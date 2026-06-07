using System.Collections.Generic;
using StudentModels;
using DataService;

namespace AppService
{
    public class StudentService
    {
        private StudentMgmtDataService stud = new StudentMgmtDataService();


        public void EnrollStudent(Student student)
        {
            if (stud.StudentExists(student.StudentNumber))
            {
                return;
            }

            stud.Add(student);
        }

        public void UpdateStudent(Student student)
        {
            Student update = stud.GetByStudentNumber(student.StudentNumber);

            if (update == null)
            {
                return;
            }

            stud.Update(student);
        }

        public void DeleteStudent(string studentNumber)
        {
            if (!stud.StudentExists(studentNumber))
            {
                return;
            }

            stud.Delete(studentNumber);
        }

        public void DeactivateStudent(string studentNumber)
        {
            if (!stud.StudentExists(studentNumber))
            {
                return;
            }

            stud.Deactivate(studentNumber);
        }

        public void StudentLeave(string studentNumber)
        {
            if (!stud.StudentExists(studentNumber))
            {
                return;
            }

            stud.Leave(studentNumber);
        }

        public Student SearchStudent(string studentNumber)
        {
            return stud.GetByStudentNumber(studentNumber);
        }

        public bool StudentExists(string studentNumber)
        {
            return stud.StudentExists(studentNumber);
        }

        public List<Student> ViewStudents()
        {
            return stud.GetStudents();
        }

        public int StudentCount()
        {
            return stud.GetStudents().Count;
        }
    }
}