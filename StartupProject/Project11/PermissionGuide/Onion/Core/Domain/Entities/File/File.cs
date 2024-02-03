using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.File;


public class File : BaseEntity {

    public string? FileName { get; set; }

    public string? Path { get; set; }

    public string? ThumbnailPath { get; set; }

    public string? StoragePath { get; set; }

    public long? Length { get; set; }

    public string? Description { get; set; }

    public string? MetaData { get; set; }

    [NotMapped]
    public override DateTime ModifiedTime { get => base.ModifiedTime; set => base.ModifiedTime = value; }

    public override bool IsPersistent { get; set; }


}
