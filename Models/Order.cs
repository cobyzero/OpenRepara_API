using System;
using System.Collections.Generic;

namespace OpenRepara_API.Models;

public partial class Order
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string TypeService { get; set; } = null!;

    public string Dispositive { get; set; } = null!;

    public string NameClient { get; set; } = null!;

    public string NumberClient { get; set; } = null!;

    public string EmailClient { get; set; } = null!;

    public string MarcaDispositive { get; set; } = null!;

    public string ModelDispositive { get; set; } = null!;

    public string? ImeiDispositive { get; set; }

    public string? PassDispositive { get; set; }

    public string? PinDispositive { get; set; }

    public string FailDispositive { get; set; } = null!;

    public string Observation { get; set; } = null!;

    public double Price { get; set; }

    public int Status { get; set; }

    public DateTime DateOrder { get; set; }
}
