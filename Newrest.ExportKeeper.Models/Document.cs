using System;
using System.Collections.Generic;

namespace Newrest.ExportKeeper.Repositories;

public partial class Document
{
    public int Id { get; set; }

    public string FileName { get; set; } = null!;

    public string? Description { get; set; }

    public byte[] Content { get; set; } = null!;

    public int? UserId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<JobAppliement> JobAppliements { get; set; } = new List<JobAppliement>();

    public virtual User? User { get; set; }
}
