using System;
using System.Collections.Generic;

namespace ApiAziendaLogin.Models;

public partial class Ruoli
{
    public int IdRuolo { get; set; }

    public string NomeRuolo { get; set; } = null!;

    public virtual ICollection<UtentiRuoli> UtentiRuoli { get; set; } = new List<UtentiRuoli>();
}
