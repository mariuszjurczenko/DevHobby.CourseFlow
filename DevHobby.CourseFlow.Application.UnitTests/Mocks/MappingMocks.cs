using AutoMapper;
using DevHobby.CourseFlow.Application.Profiles;

namespace DevHobby.CourseFlow.Application.UnitTests.Mocks;

public class MappingMocks
{
    public static IMapper GetMapper()
    {
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });

        return configurationProvider.CreateMapper();
    }
}
