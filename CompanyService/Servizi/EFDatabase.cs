
using Microsoft.EntityFrameworkCore;

namespace CompanyService;

public class EFDatabase : IDatabaseService
{
    private FlightSimulatorDBContext _context;
    public EFDatabase(FlightSimulatorDBContext context)
    {
        _context = context;
    }

    public async Task<Aereo> AddAereoAFlotta(long idFlotta, string codiceAereo, string colore, long numeroPosti)
    {
        Aereo a = new Aereo(idFlotta, codiceAereo, colore, numeroPosti);
        await _context.Aerei.AddAsync(a);
        await _context.SaveChangesAsync();
        return a;
    }

    public async Task<Flotta> CreateFlotta(string nome)
    {
        Flotta f = Flotta.FlottaFactory(nome);
        await _context.Flotte.AddAsync(f);
        await _context.SaveChangesAsync();

        return await GetFlottaByIdFlotta(f.FlottaId);
    }

    public async Task DeleteAereoDaIdAereo(long idAereo)
    {
        var aereo = await GetAereoDaIdAereo(idAereo);
        if (aereo != null)
        {
            _context.Aerei.Remove(aereo);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Aereo?> GetAereoDaIdAereo(long idAereo)
    {
        return await _context.Aerei.FirstOrDefaultAsync(
            x => x.AereoId == idAereo
        );
    }

    public async Task<List<Flotta>> GetElencoFlotte()
    {
        return await _context.Flotte
        .Include(b => b.Aerei).ToListAsync();
    }

    public async Task<Flotta?> GetFlottaByIdFlotta(long idFlotta)
    {
        return await _context.Flotte.Where(
           x => x.FlottaId == idFlotta
       )
       .Include(b => b.Aerei)
       .FirstOrDefaultAsync();
    }

    public async Task<Aereo?> UpdateAereoByIdAereo(long idAereo, string codiceAereo, string colore, long numeroDiPosti)
    {
        var aereo = await GetAereoDaIdAereo(idAereo);
        if (aereo != null)
        {
            aereo.UpdateInformazioniAereo(codiceAereo, colore, numeroDiPosti);
            await _context.SaveChangesAsync();
        }           
        return aereo;
    }

    public async Task<Volo?> GetVoloByIdVolo (long idVolo)
    {
        return await _context.Voli.FirstOrDefaultAsync(
           x => x.VoloId == idVolo
       );
    }

    public async Task<Volo?> AddVolo (long aereoId, int postiResidui, double costoPosto, string partenza, 
                    string destinazione, DateTime orarioPartenza, DateTime orarioDestinazione)
    {
        Volo v = new Volo (aereoId, postiResidui, costoPosto, partenza, destinazione, orarioPartenza, orarioDestinazione);
        await _context.Voli.AddAsync(v);
        await _context.SaveChangesAsync();
        return v;
    }

    public async Task DeleteVoloByIdVolo(long idVolo){
        var volo = await GetVoloByIdVolo(idVolo);
        if (volo != null)
        {
            _context.Voli.Remove(volo);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Volo?> UpdateVoloByIdVolo (long idVolo, long aereoId, int postiResidui, double costoPosto, string partenza, 
                    string destinazione, DateTime orarioPartenza, DateTime orarioDestinazione)
        {        
        var volo = await GetVoloByIdVolo(idVolo);
        if (volo != null)
        {
            volo.UpdateInformazioniVolo(aereoId, postiResidui, costoPosto, partenza, destinazione, orarioPartenza, orarioDestinazione);
            await _context.SaveChangesAsync();
        }           
        return volo;
    }
    
    public async Task<Biglietto?> GetBigliettoByIdBiglietto (long idBiglietto)
    {
        return await _context.Biglietti.FirstOrDefaultAsync(
           x => x.BigliettoId == idBiglietto
        );
    }

    public async Task<Biglietto?> AddBiglietto (long voloId, int numeroPostiRichiesti, double importoTotale, DateTime dataAcquisto)
    {
        Biglietto b = new Biglietto (voloId, numeroPostiRichiesti, importoTotale, dataAcquisto);
        await _context.Biglietti.AddAsync(b);
        await _context.SaveChangesAsync();
        return b;
    }

    public async Task<List<Biglietto>> GetBigliettoByIdVolo (long idVolo)
    {
        return await _context.Biglietti.Where(
           x => x.VoloId == idVolo
        ).ToListAsync();
    }

    public async Task DeleteBigliettoByIdBiglietto (long idBiglietto){
        var biglietto = await GetBigliettoByIdBiglietto (idBiglietto);
        if (biglietto != null)
        {
            _context.Biglietti.Remove(biglietto);
            await _context.SaveChangesAsync();
        }
    }
}
