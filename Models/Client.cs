using System;
using System.Collections.Generic;

namespace OpenRepara_API.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Number { get; set; } = null!;
}
