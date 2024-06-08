using System;
using System.Collections.Generic;

namespace Newrest.ExportKeeper.Repositories;

public partial class Job
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Requirements { get; set; } = null!;

    public int PosterId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<JobAppliement> JobAppliements { get; set; } = new List<JobAppliement>();

    public virtual User Poster { get; set; } = null!;
}
