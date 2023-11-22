using API_Project.DataTransferObjects;
using API_Project.Domain.Models;
using AutoMapper;

namespace API_Project.API_Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();

        }

    }
}
