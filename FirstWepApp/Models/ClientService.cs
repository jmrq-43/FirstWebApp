using System;
using System.Collections.Generic;

namespace FirstWepApp.Models;

public partial class ClientService
{
    public int ClientId { get; set; }

    public int ServiceId { get; set; }

    public DateOnly? DateHiring { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
