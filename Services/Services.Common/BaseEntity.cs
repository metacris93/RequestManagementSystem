namespace Services.Common;

public class BaseEntity
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    //public long? CreatedBy { get; set; }
    //public long? UpdatedBy { get; set; }
    //public long? DeletedBy { get; set; }
}
