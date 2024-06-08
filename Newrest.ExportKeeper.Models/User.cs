using System;
using System.Collections.Generic;

namespace Newrest.ExportKeeper.Repositories;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int RoleId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();

    public virtual ICollection<JobAppliement> JobAppliements { get; set; } = new List<JobAppliement>();

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();

    public virtual Role Role { get; set; } = null!;
}
