using System;
using System.Collections.Generic;

namespace PruebaTecnicaGissa.Models;

public partial class TestUser
{
    public int UserPrimaryId { get; set; }

    public string UserLastName { get; set; } = null!;

    public string? UserNickName { get; set; }

    public string? UserUserType { get; set; }

    public string? UserTypeCed { get; set; }

    public string? UserCed { get; set; }

    public string? UserPass { get; set; }

    public string? UserEmail { get; set; }

    public virtual ICollection<TestContact> TestContacts { get; } = new List<TestContact>();

    public virtual ICollection<TestHability> TestHabilities { get; } = new List<TestHability>();
}
