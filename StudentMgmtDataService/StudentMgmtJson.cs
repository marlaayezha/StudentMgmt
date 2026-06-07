using DataService;
using StudentModels;
using System.Text.Json;

namespace StudentDataService
{
    public class StudentJsonData : IStudentMgmtDataService
    {
        private List<Student> students = new List<Student>();

        private string _jsonFileName;

        public StudentJsonData()
        {
            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/Students.json";

            PopulateJsonFile();
        }

        private void PopulateJsonFile()
        {
            RetrieveDataFromJsonFile();

            if (students.Count <= 0)
            {
                students.Add(new Student
                {
                    FirstName = "Marla",
                    LastName = "Miranda",
                    StudentNumber = "2026-0001",
                    ContactNumber = "09123456789",
                    Address = "Binan City",
                    Status = "Active"

                });

                students.Add(new Student
                {
                    FirstName = "Mary",
                    LastName = "Freo",
                    StudentNumber = "2026-0002",
                    ContactNumber = "09987654321",
                    Address = "Bacoor City",
                    Status = "Active"
                });

                students.Add(new Student
                {
                    FirstName = "Yuki",
                    LastName = "San",
                    StudentNumber = "2026-0003",
                    ContactNumber = "09111222333",
                    Address = "Tokyo, Japan",
                    Status = "Active"
                });

                SaveDataToJsonFile();
            }
        }

        private void SaveDataToJsonFile()
        {
            using (var outputStream = File.Create(_jsonFileName))
            {
                JsonSerializer.Serialize<List<Student>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {SkipValidation = true,Indented = true }), students);
            }
        }

        private void RetrieveDataFromJsonFile()
        {
            using (var jsonFileReader = File.OpenText(_jsonFileName))
            {
                students = JsonSerializer.Deserialize<List<Student>>
                    (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true }).ToList();
            }
        }

        public void Add(Student student)
        {
            students.Add(student);
            SaveDataToJsonFile();
        }

        public List<Student> GetStudents()
        {
            RetrieveDataFromJsonFile();
            return students;
        }

        public Student GetByStudentNumber(string studentNumber)
        {
            RetrieveDataFromJsonFile();
            return students.Where(x => x.StudentNumber == studentNumber).FirstOrDefault();
        }

        public void Update(Student student)
        {
            RetrieveDataFromJsonFile();

            var existingStudent = students.FirstOrDefault(x => x.StudentId == student.StudentId);

            if (existingStudent != null)
            {
                existingStudent.StudentNumber = student.StudentNumber;
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
            }

            SaveDataToJsonFile();
        }

        public bool StudentNumberExists(string studentNumber)
        {
            RetrieveDataFromJsonFile();
            return students.Where(x => x.StudentNumber == studentNumber).Any();
        }

        public bool StudentExists(string studentNumber)
        {
            RetrieveDataFromJsonFile();
            return students.Where(x => x.StudentNumber == studentNumber).Any();
        }

        public void Delete(string studentNumber)
        {
            RetrieveDataFromJsonFile();
            var student = GetByStudentNumber(studentNumber);

            if (student != null)
            {
                students.Remove(student);
            }
            SaveDataToJsonFile();
        }

        public void Deactivate(string studentNumber)
        {
            RetrieveDataFromJsonFile();
            var student = GetByStudentNumber(studentNumber);

            if (student != null)
            {
                student.Status = "Deactivated";
            }
            SaveDataToJsonFile();
        }

        public void Leave(string studentNumber)
        {
            RetrieveDataFromJsonFile();
            var student = GetByStudentNumber(studentNumber);

            if (student != null)
            {
                student.Status = "On Leave";
            }
            SaveDataToJsonFile();
        }
    }
}