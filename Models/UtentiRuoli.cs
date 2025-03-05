using System;
using System.Collections.Generic;

namespace ApiAziendaLogin.Models;

public partial class UtentiRuoli
{
    public int IdUtenteRuolo { get; set; }

    public int IdUtente { get; set; }

    public int IdRuolo { get; set; }

    public virtual Ruoli Ruoli { get; set; } = null!;

    public virtual Utenti Utenti { get; set; } = null!;
}
