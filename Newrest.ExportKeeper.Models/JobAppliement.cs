using System;
using System.Collections.Generic;

namespace Newrest.ExportKeeper.Repositories;

public partial class JobAppliement
{
    public int Id { get; set; }

    public int JobId { get; set; }

    public int UserId { get; set; }

    public int DocumentId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Document Document { get; set; } = null!;

    public virtual Job Job { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
