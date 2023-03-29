using System;
using System.Collections.Generic;

namespace OpenRepara_API.Models;

public partial class Venta
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Client { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string Type { get; set; } = null!;

    public double Price { get; set; }
}
