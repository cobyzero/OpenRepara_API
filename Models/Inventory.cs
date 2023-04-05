using System;
using System.Collections.Generic;

namespace OpenRepara_API.Models;

public partial class Inventory
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string? Imei { get; set; }

    public string? Description { get; set; }

    public string TypeService { get; set; } = null!;
}
