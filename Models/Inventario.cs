using System;
using System.Collections.Generic;

namespace OpenRepara_API.Models;

public partial class Inventario
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string? Serial { get; set; }

    public string? Imei { get; set; }

    public string? Description { get; set; }

    public string Type { get; set; } = null!;
}
