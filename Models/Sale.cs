using System;
using System.Collections.Generic;

namespace OpenRepara_API.Models;

public partial class Sale
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string ClientName { get; set; } = null!;

    public DateTime DateService { get; set; }

    public string TypeService { get; set; } = null!;

    public double PriceService { get; set; }
}
