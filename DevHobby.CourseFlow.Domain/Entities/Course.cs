﻿using DevHobby.CourseFlow.Domain.Common;

namespace DevHobby.CourseFlow.Domain.Entities;

public class Course : AuditableEntity
{
    public Guid CourseId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public string? Author { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime PublicationDate { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = default!;
}
