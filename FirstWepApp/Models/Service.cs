using System;
using System.Collections.Generic;

namespace FirstWepApp.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string DescriptionService { get; set; } = null!;

    public decimal? Price { get; set; }

    public virtual ICollection<ClientService> ClientServices { get; set; } = new List<ClientService>();
}
