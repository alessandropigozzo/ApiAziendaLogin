using System;
using System.Collections.Generic;

namespace ApiAziendaLogin.Models;

public partial class Anagrafiche
{
    public int IdAnagrafica { get; set; }

    public string Nazionalita { get; set; } = null!;

    public int Eta { get; set; }

    public string Via { get; set; } = null!;

    public string Indirizzo { get; set; } = null!;

    public int Cap { get; set; }

    public virtual Utenti? Utenti { get; set; }
}
