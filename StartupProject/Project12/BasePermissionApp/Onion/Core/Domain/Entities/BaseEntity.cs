namespace Domain.Entities;


public class BaseEntity {
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedTime { get; set; } = DateTime.UtcNow;
    public virtual DateTime ModifiedTime { get; set; }
    public DateTime DeletedTime { get; set; }
    public virtual bool IsPersistent { get; set; }   //TODO IsPersistent -> Persistent isimlendir.
    public bool Active { get; set; } = true;
}