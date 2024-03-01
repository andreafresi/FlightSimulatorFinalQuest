using System.Net;
using System.Security.AccessControl;
using CompanyService;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CompanyService.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/volo")]
public class VoloController : ControllerBase
{
    private IDatabaseService _databaseService;

    public VoloController(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    // Get(long idVolo)
    [HttpGet("GetIdVolo")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(VoloApi), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get (long idVolo)
    {
        var volo = await _databaseService.GetVoloByIdVolo(idVolo);
        if(volo == null)
        {
            return NotFound("Non ho trovato il volo");
        }

        var result = new VoloApi(volo.VoloId, volo.AereoId, volo.PostiResidui,
        volo.CostoPosto, volo.Partenza, volo.Destinazione, volo.OrarioPartenza, volo.OrarioDestinazione);
        return Ok(result);
    }

    // GetVoliConPostiDisponibili()
    [HttpGet("GetVoliConPostiDisponibili")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(VoloApi), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetVoliConPostiDisponibili ()
    {
        var v = await _databaseService.GetListaVoli();
        List<Volo> voloPulita = new List<Volo>();
        foreach (var c in v)
        {
            if (c.PostiResidui > 0)
            {
                voloPulita.Add(c);
            }
        }

        return Ok(voloPulita);
    }

    // Post(CreateVoloRequest)
    [HttpPost("CreateVolo")]
    [ProducesResponseType(typeof(long), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(VoloApi), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Post(CreateVoloRequest request)
    {
        var voloBl = await _databaseService.AddVolo(request.AereoId, request.PostiResidui, request.CostoPosto, request.Partenza, request.Destinazione, request.OrarioPartenza, request.OrarioPartenza);
        
        var voloApi = new VoloApi (voloBl.AereoId, voloBl.PostiResidui, voloBl.CostoPosto, voloBl.Partenza, voloBl.Destinazione, voloBl.OrarioPartenza, voloBl.OrarioDestinazione);

        return Ok(voloApi);
    }

    // Delete(long idVolo)
    [HttpDelete("DeleteVolo")]
    [ProducesResponseType(typeof(long), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(VoloApi), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete (long idVolo)
    {
        // Recupero le informazioni dal db     
        var volo = await _databaseService.GetVoloByIdVolo(idVolo);
        if (volo == null)
        {
            return NotFound();
        }
        await _databaseService.DeleteVoloByIdVolo(idVolo);
        return Ok();
    }

    // Put(UpdateVoloRequest)
    [HttpPut("UpdateVolo")]
    [ProducesResponseType(typeof(long), (int)HttpStatusCode.NotFound)]
    [ProducesResponseType(typeof(VoloApi), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Put(UpdateVoloRequest request)
    {
        var volo = await _databaseService.GetVoloByIdVolo(request.VoloId);
        if (volo == null)
        {
            return NotFound();
        }

        var voloBl = await _databaseService.UpdateVoloByIdVolo(request.VoloId, request.AereoId, request.PostiResidui, request.CostoPosto, request.Partenza, request.Destinazione, request.OrarioPartenza, request.OrarioPartenza);
        var voloApi = new VoloApi (voloBl.VoloId, voloBl.AereoId, voloBl.PostiResidui, voloBl.CostoPosto, voloBl.Partenza, voloBl.Destinazione, voloBl.OrarioPartenza, voloBl.OrarioDestinazione);
        
        return Ok(voloApi);
    }

}