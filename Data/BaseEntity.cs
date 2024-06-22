namespace DeliveryApp.Data;

public class BaseEntity : IAuditBase
{
    public int Id { get; set; }
    public DateTime CreatedOn {get; set; }
    public DateTime? UpdatedOn {get; set; }
}
