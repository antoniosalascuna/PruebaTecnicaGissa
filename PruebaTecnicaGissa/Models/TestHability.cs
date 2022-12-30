using System;
using System.Collections.Generic;

namespace PruebaTecnicaGissa.Models;

public partial class TestHability
{
    public int HabPrimaryId { get; set; }

    public string? HabName { get; set; }

    public string? HabDescripcion { get; set; }

    public int? UserPrimaryId { get; set; }

    public virtual TestUser? UserPrimary { get; set; }
}
