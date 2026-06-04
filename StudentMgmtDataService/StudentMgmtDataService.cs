using System.Collections.Generic;
using StudentModels;

namespace DataService
{
    public class StudentDataService
    {
        List<Student> StudentList = new List<Student>();

        public List<Student> GetAllStudents()
        {
            return StudentList;
        }

        public void AddStudent(Student student)
        {
            StudentList.Add(student);
        }

        public void UpdateStudent(Student oldStudent, Student newStudent)
        {
            oldStudent.FirstName = newStudent.FirstName;
            oldStudent.LastName = newStudent.LastName;
            oldStudent.ContactNumber = newStudent.ContactNumber;
            oldStudent.Address = newStudent.Address;
        }

        public void DeleteStudent(Student student)
        {
            StudentList.Remove(student);
        }

        public void DeactivateStudent(Student student)
        {
            student.Status = "Deactivated";
        }

        public void StudentLeave(Student student)
        {
            student.Status = "On Leave";
        }

        public Student SearchStudent(string studentNumber)
        {
            return StudentList.Find(x => x.StudentNumber == studentNumber);
        }
        public bool StudentExists(string studentNumber)
        {
            return StudentList.Exists(x => x.StudentNumber == studentNumber);
            
        }


    }
}

