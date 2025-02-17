using System;
using System.Collections.Generic;

namespace FirstWepApp.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<ClientService> ClientServices { get; set; } = new List<ClientService>();
}
