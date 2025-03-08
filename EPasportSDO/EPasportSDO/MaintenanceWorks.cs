using System;
using System.Collections.Generic;

namespace EPasportSDO;

public partial class MaintenanceWorks
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime Time { get; set; }

    public string EngineerName { get; set; } = null!;

    public decimal PriceOfWork { get; set; }

    public Guid TechObjectId { get; set; }

    public virtual TechObject TechObject { get; set; } = null!;
}
