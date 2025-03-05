using System;
using System.Collections.Generic;

namespace ApiAziendaLogin.Models;

public partial class Immagini
{
    public int IdImmagine { get; set; }

    public string Img1 { get; set; } = null!;

    public string Img2 { get; set; } = null!;

    public string Img3 { get; set; } = null!;

    public virtual Utenti? Utenti { get; set; }
}
