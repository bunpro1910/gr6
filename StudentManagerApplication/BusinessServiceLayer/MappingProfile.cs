using AutoMapper;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServiceLayer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<StudentEntity, StudentDTO>();
            CreateMap<StudentDTO, StudentEntity>();

        }
    }
}
