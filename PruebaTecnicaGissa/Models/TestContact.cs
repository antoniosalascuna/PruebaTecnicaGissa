using System;
using System.Collections.Generic;

namespace PruebaTecnicaGissa.Models;

public partial class TestContact
{
    public int TelPrimaryId { get; set; }

    public string? TelNumber { get; set; }

    public string? TelType { get; set; }

    public string? TelState { get; set; }

    public int? UserPrimaryId { get; set; }

    public virtual TestUser? UserPrimary { get; set; }
}
