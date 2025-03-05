using System;
using System.Collections.Generic;

namespace ApiAziendaLogin.Models;

public partial class Utenti
{
    public int IdUtente { get; set; }

    public string Email { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public string CodiceFiscale { get; set; } = null!;

    public int IdAnagrafica { get; set; }

    public int IdImmagine { get; set; }

    public virtual Anagrafiche Anagrafiche { get; set; } = null!;

    public virtual Immagini Immagini { get; set; } = null!;

    public virtual ICollection<UtentiRuoli> UtenteRuoli { get; set; } = new List<UtentiRuoli>();
}
