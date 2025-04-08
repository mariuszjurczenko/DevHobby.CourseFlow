using DevHobby.CourseFlow.Domain.Common;

namespace DevHobby.CourseFlow.Domain.Entities;

public class Order : AuditableEntity
{
    public Guid OrderId { get; set; }
    public Guid UserId { get; set; }
    public int OrderTotal { get; set; }
    public DateTime OrderPlaced { get; set; }
    public bool IsOrderPaid { get; set; }
}
