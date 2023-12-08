
using System.Xml.Linq;

namespace DataAccessLayer
{
    public class StudentRepository
    {
        private readonly ApplicationContext dbContext;

        public StudentRepository(ApplicationContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<StudentEntity> Get()
        {
            return dbContext.Students.ToList();
        }
        public List<StudentEntity> GetFilterStudent(string? name, string? gradeId, string? sortType, string? sortField, int pageNumber, int pageSize)
        {

            IEnumerable<StudentEntity> students = Get();
            if (name != null)
            {
                students = students.Where(x => x.StudentName.Contains(name));
            }
            if (gradeId != null)
            {
                students = students.Where(x => x.GradeId.Contains(gradeId));
            }

            if (sortType != null)
            {
                if (sortField != null)
                {
                    char[] text = sortField.ToCharArray();
                    text[0] = char.ToUpper(text[0]);
                    sortField = new String(text);
                }
                students = sortType == "desc"
                    ? students.OrderByDescending(s => !String.IsNullOrEmpty(sortField) ? s.GetType().GetProperty(sortField)?.GetValue(s, null) : s.StudentName)
                    : students.OrderBy(s => !String.IsNullOrEmpty(sortField) ? s.GetType().GetProperty(sortField)?.GetValue(s, null) : s.StudentName);
            }
            if (pageNumber >= 1 && pageSize >= 1)
            {

                students = PaginatedList<StudentEntity>.Create(students, pageSize, pageNumber);
            }
            return students.ToList();
        }
        public StudentEntity Get(int id)
        {
            return dbContext.Students.FirstOrDefault(x => x.StudentId.Equals(id));
        }
        public void Post(StudentEntity student)
        {
            dbContext.Students.Add(student);
            dbContext.SaveChanges();
        }

        public bool Put(int id, StudentEntity student)
        {
            var studentUpdate = dbContext.Students.FirstOrDefault(x => x.StudentId.Equals(id));

            if (studentUpdate == null)
            {
                return false;
            }

            dbContext.Students.Update(student);
            dbContext.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var student = dbContext.Students.FirstOrDefault(x => x.StudentId.Equals(id));
            if (student == null)
            {
                return false;
            }
            dbContext.Students.Remove(student);
            dbContext.SaveChanges();
            return true;
        }
    }
}
