using AutoMapper;
using DevHobby.CourseFlow.Application.Features.Courses;
using DevHobby.CourseFlow.Domain.Entities;

namespace DevHobby.CourseFlow.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Course, CourseListVm>().ReverseMap();
        CreateMap<Course, CourseDetailVm>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
    }
}
