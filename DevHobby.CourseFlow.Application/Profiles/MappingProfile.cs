using AutoMapper;
using DevHobby.CourseFlow.Application.Features.Categories.Queries.GetCategoriesList;
using DevHobby.CourseFlow.Application.Features.Categories.Queries.GetCategoriesListWithCourses;
using DevHobby.CourseFlow.Application.Features.Courses.Commands.CreateCourse;
using DevHobby.CourseFlow.Application.Features.Courses.Commands.UpdateCourse;
using DevHobby.CourseFlow.Application.Features.Courses.Queries.GetCourseDetail;
using DevHobby.CourseFlow.Application.Features.Courses.Queries.GetCoursesList;
using DevHobby.CourseFlow.Domain.Entities;

namespace DevHobby.CourseFlow.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Course, CourseListVm>().ReverseMap();
        CreateMap<Course, CourseDetailVm>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Category, CategoryListVm>().ReverseMap();
        CreateMap<Category, CategoryCourseListVm>();
        CreateMap<Course, CreateCourseCommand>().ReverseMap();
        CreateMap<Course, UpdateCourseCommand>().ReverseMap();
    }
}
