using ApiAziendaLogin.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class MagazzinoController : ControllerBase
{
    private readonly ILogger<MagazzinoController> _logger;

    public MagazzinoController(ILogger<MagazzinoController> logger)
    {
        _logger = logger;
    }


    private static readonly List<Prodotto> Prodotti = new List<Prodotto>
        {
            new Prodotto { Id = 1, Nome = "Prodotto 1", Prezzo = 10.5 },
            new Prodotto { Id = 2, Nome = "Prodotto 2", Prezzo = 20.0 },
            new Prodotto { Id = 3, Nome = "Prodotto 3", Prezzo = 15.3 },
        };

    [HttpGet("GetProdotto", Name = "GetSingoloProdotto")]
    public IActionResult GetSingoloProdotto()
    {
        string prova = "Prodotto 1";
        _logger.LogInformation("Esempio di log");
        return Ok(prova);
    }

    [HttpGet("GetProdotto/{id}")]
    public IActionResult GetProdotto(int id)
    {
        var prodotto = Prodotti.FirstOrDefault(p => p.Id == id);

        if (prodotto == null)
        {
            _logger.LogWarning($"Prodotto con ID {id} non trovato.");
            return NotFound();
        }

        _logger.LogInformation($"Prodotto con ID {id} trovato.");
        return Ok(prodotto);
    }

    [HttpGet("GetListProdotti", Name = "GetTuttiProdotti")]
    public IActionResult GetTuttiProdotti()
    {
        _logger.LogInformation("Recuperando tutti i prodotti");
        return Ok(Prodotti);
    }
}
