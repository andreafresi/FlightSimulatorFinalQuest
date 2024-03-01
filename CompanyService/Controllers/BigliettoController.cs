using System.Formats.Asn1;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace CompanyService.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/biglietto")]
public class BigliettoController : ControllerBase
{
    private IDatabaseService _databaseService;

    public BigliettoController(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }


    // Get(long idBiglietto)
    [HttpGet("GetBiglietto")]
    [ProducesResponseType(typeof(int), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BigliettoApi), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get(long bigliettoid)
    {

        var biglietto = await _databaseService.GetBigliettoByIdBiglietto(bigliettoid);
        if (biglietto == null)
        {
            return NotFound("Biglietto non esistente");
        }

        var result = new BigliettoApi(biglietto.BigliettoId, biglietto.VoloId, biglietto.NumeroPostiRichiesti, biglietto.ImportoTotale, Convert.ToDateTime(biglietto.DataAcquisto));

        return Ok(result);
    }

    // Post(CreateBigliettoRequest)


    [HttpPost("PostBiglietti")]
    [ProducesResponseType(typeof(long), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(BigliettoApi), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Post(CreateBigliettoRequest request)
    {

        var volo = (await _databaseService.GetVoloByIdVolo(request.VoloId));

        if (volo == null)
        {
            return NotFound("Volo non esistente");
        }
        if (volo.PostiResidui < request.NumPostReq)
        {
            return Ok("Biglietto non acquistato posti");
        }
        volo.PostiResidui = volo.PostiResidui - request.NumPostReq;

        // Inserimento nel database
        var bigliettobl = await _databaseService.AddBiglietto(request.VoloId, request.NumPostReq, volo.CostoPosto * request.NumPostReq, DateTime.Now);

        // Converto il modello di bl in quello api
        var bigliettoapi = new BigliettoApi(bigliettobl.VoloId, bigliettobl.NumeroPostiRichiesti, bigliettobl.ImportoTotale, bigliettobl.DataAcquisto);

        // Restituisco il modello api
        return Ok(bigliettoapi);
    }

    // GetBigliettiByVoloId(long idVolo)
    [HttpGet("GetAllBiglietti")]
    [ProducesResponseType(typeof(long), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(List<BigliettoApi>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetListaBiglietti(long idVolo)
    {

        var ListaBigliettiByIdVolo = await _databaseService.GetBigliettoByIdVolo(idVolo);
        if (ListaBigliettiByIdVolo == null)
        {
            return NotFound("Non ho trovato l'id volo");
        }

        return Ok(ListaBigliettiByIdVolo);
    }

    [HttpDelete("DeleteBiglietto")]
    [ProducesResponseType(typeof(long), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    // Delete(long idBiglietto)
    public async Task<IActionResult> DeleteBiglietti(long BigliettoId)
    {

        var biglietto = await _databaseService.GetBigliettoByIdBiglietto(BigliettoId);
        if (biglietto == null)
        {
            return NotFound("Biglietto non esistente");
        }
        var volo = await _databaseService.GetVoloByIdVolo(biglietto.VoloId);
        volo.PostiResidui += biglietto.NumeroPostiRichiesti;
        await _databaseService.DeleteBigliettoByIdBiglietto(BigliettoId);
        return Ok();
    }
}
