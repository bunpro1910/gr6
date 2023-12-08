using AutoMapper;
using DataAccessLayer;

namespace BusinessServiceLayer
{
    public class StudentService
    {
        private readonly StudentRepository studentRepository;
        private readonly IMapper mapper;
        public StudentService(StudentRepository studentRepository,IMapper mapper) { 
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }

        public List<StudentDTO> Get()
        {


            return mapper.Map<List<StudentDTO>>(studentRepository.Get());
        }
        public List<StudentDTO> GetFilterStudent(string? name, string? gradeId, string? sortType, string? sortField, int pageNumber, int pageSize)
        {


            return mapper.Map<List<StudentDTO>>(studentRepository.GetFilterStudent(name, gradeId, sortType,sortField,pageNumber,pageSize));
        }
        public StudentDTO Get(int id)
        {


            return mapper.Map<StudentDTO>(studentRepository.Get(id));
        }
        public void Post(StudentDTO student)    
        {
            studentRepository.Post(mapper.Map<StudentEntity>(student));
        }
        public bool Put(int id, StudentDTO student)
        {
            return studentRepository.Put(id,mapper.Map<StudentEntity>(student));
        }
        public bool Delete(int id)
        {
            return studentRepository.Delete(id);

        }
    }
}