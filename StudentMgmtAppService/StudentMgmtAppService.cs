using System.Collections.Generic;
using StudentModels;
using DataService;

namespace AppService
{
    public class StudentService
    {
        StudentDataService stud = new StudentDataService();

        public void EnrollStudent(Student student)
        {
            if (stud.StudentExists(student.StudentNumber))
            {
                return;
            }

            stud.AddStudent(student);
        }

        public void UpdateStudent(Student student)
        {

            Student update = stud.SearchStudent(student.StudentNumber);

            if (student == null)
            {
                return;
            }

            stud.UpdateStudent(update, student);
        }

        public void DeleteStudent(string studentNumber)
        {

            Student student = stud.SearchStudent(studentNumber);


            if (student == null)
            {
                return;
            }

            stud.DeleteStudent(student);
        }

        public void DeactivateStudent(string studentNumber)
        {

            Student student = stud.SearchStudent(studentNumber);


            if (student == null)
            {
                return;
            }

            stud.DeactivateStudent(student);
        }

        public void StudentLeave(string studentNumber)
        {

            Student student = stud.SearchStudent(studentNumber);


            if (student == null)
            {
                return;
            }

            stud.StudentLeave(student);
        }

        public Student SearchStudent(string studentNumber)
        {
            return stud.SearchStudent(studentNumber);
        }

        public bool StudentExists(string studentNumber)
        {
            return stud.StudentExists(studentNumber);
        }

        public List<Student> ViewStudents()
        {
            return stud.GetAllStudents();
        }

        public int StudentCount()
        {
            return stud.GetAllStudents().Count;
        }
    }
}

