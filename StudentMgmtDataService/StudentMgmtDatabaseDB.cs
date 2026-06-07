using DataService;
using Microsoft.Data.SqlClient;
using StudentModels;
using System;
using System.Collections.Generic;

namespace DataService
{
    public class StudentDatabaseDB : IStudentMgmtDataService
    {
        private string connectionString =
            "Data Source=localhost\\SQLEXPRESS; Initial Catalog=StudentMgmt; Integrated Security=True; TrustServerCertificate=True;";

        private SqlConnection sqlConnection;

        public StudentDatabaseDB()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public void Add(Student student)
        {
            var insertStatement = "INSERT INTO StudentTbl VALUES (@FirstName, @LastName, @StudentNumber, @ContactNumber, @Address, @Status)";
            SqlCommand cmd = new SqlCommand(insertStatement, sqlConnection);
            cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
            cmd.Parameters.AddWithValue("@LastName", student.LastName);
            cmd.Parameters.AddWithValue("@StudentNumber", student.StudentNumber);
            cmd.Parameters.AddWithValue("@ContactNumber", student.ContactNumber);
            cmd.Parameters.AddWithValue("@Address", student.Address);
            cmd.Parameters.AddWithValue("@Status", student.Status);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public Student GetByStudentNumber(string studentNumber)
        {
            var selectStatement = "SELECT * FROM StudentTbl WHERE StudentNumber = @StudentNumber";
            SqlCommand cmd = new SqlCommand(selectStatement, sqlConnection);
            cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);
            sqlConnection.Open();
            SqlDataReader studentReader = cmd.ExecuteReader();

            Student student = null;
            if (studentReader.Read())
            {
                student = new Student();
                student.FirstName = studentReader["FirstName"].ToString();
                student.LastName = studentReader["LastName"].ToString();
                student.StudentNumber = studentReader["StudentNumber"].ToString();
                student.ContactNumber = studentReader["ContactNumber"].ToString();
                student.Address = studentReader["Address"].ToString();
                student.Status = studentReader["Status"].ToString();
            }

            sqlConnection.Close();
            return student;
        }

        public bool StudentExists(string studentNumber)
        {
            var selectStatement = "SELECT 1 FROM StudentTbl WHERE StudentNumber = @StudentNumber";
            SqlCommand cmd = new SqlCommand(selectStatement, sqlConnection);
            cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);
            sqlConnection.Open();
            SqlDataReader studentReader = cmd.ExecuteReader();
            bool exists = studentReader.Read();
            sqlConnection.Close();
            return exists;
        }

        public void Update(Student student)
        {
            var updateStatement = "UPDATE StudentTbl SET FirstName = @FirstName, LastName = @LastName, ContactNumber = @ContactNumber, Address = @Address, Status = @Status WHERE StudentNumber = @StudentNumber";
            SqlCommand cmd = new SqlCommand(updateStatement, sqlConnection);
            cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
            cmd.Parameters.AddWithValue("@LastName", student.LastName);
            cmd.Parameters.AddWithValue("@ContactNumber", student.ContactNumber);
            cmd.Parameters.AddWithValue("@Address", student.Address);
            cmd.Parameters.AddWithValue("@Status", student.Status);
            cmd.Parameters.AddWithValue("@StudentNumber", student.StudentNumber);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void Delete(string studentNumber)
        {
            var deleteStatement = "DELETE FROM StudentTbl WHERE StudentNumber = @StudentNumber";
            SqlCommand cmd = new SqlCommand(deleteStatement, sqlConnection);
            cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void Deactivate(string studentNumber)
        {
            var updateStatement = "UPDATE StudentTbl SET Status = 'Deactivated' WHERE StudentNumber = @StudentNumber";
            SqlCommand cmd = new SqlCommand(updateStatement, sqlConnection);
            cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void Leave(string studentNumber)
        {
            var updateStatement = "UPDATE StudentTbl SET Status = 'On Leave' WHERE StudentNumber = @StudentNumber";
            SqlCommand cmd = new SqlCommand(updateStatement, sqlConnection);
            cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public List<Student> GetStudents()
        {
            var selectStatement = "SELECT * FROM StudentTbl";
            SqlCommand cmd = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader studentReader = cmd.ExecuteReader();

            var students = new List<Student>();
            while (studentReader.Read())
            {
                Student student = new Student();
                student.FirstName = studentReader["FirstName"].ToString();
                student.LastName = studentReader["LastName"].ToString();
                student.StudentNumber = studentReader["StudentNumber"].ToString();
                student.ContactNumber = studentReader["ContactNumber"].ToString();
                student.Address = studentReader["Address"].ToString();
                student.Status = studentReader["Status"].ToString();
                students.Add(student);
            }

            sqlConnection.Close();
            return students;
        }
    }
}
