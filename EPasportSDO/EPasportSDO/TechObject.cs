using System;
using System.Collections.Generic;

namespace EPasportSDO;

public partial class TechObject
{
    public Guid Id { get; set; }

    public string Number { get; set; } = null!;

    public string Series { get; set; } = null!;

    public DateTime ProductionTime { get; set; }

    public DateTime DateOfSale { get; set; }

    public decimal Price { get; set; }

    public string SellerName { get; set; } = null!;

    public virtual ICollection<MaintenanceWorks> MaintenanceWorksSets { get; set; } = new List<MaintenanceWorks>();
}
