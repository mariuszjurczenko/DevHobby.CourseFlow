namespace DevHobby.CourseFlow.Api.Utility;

public class FileResultContentTypeAttribute : Attribute
{
    public FileResultContentTypeAttribute(string contentType)
    {
        ContentType = contentType;
    }

    public string ContentType { get; }
}
