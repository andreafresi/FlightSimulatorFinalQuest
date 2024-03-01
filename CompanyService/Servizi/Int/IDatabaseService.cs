namespace CompanyService;

public interface IDatabaseService
{
    Task<Aereo?> GetAereoDaIdAereo(long idAereo);

    Task<Flotta?> GetFlottaByIdFlotta(long idFlotta);

    Task<Aereo> AddAereoAFlotta(long idFlotta, string codiceAereo,
    string colore, long numeroPosti);

    Task DeleteAereoDaIdAereo(long idAereo);

    Task<Aereo?> UpdateAereoByIdAereo(long idAereo, string codiceAereo, string colore, long numeroDiPosti);

    Task<List<Flotta>> GetElencoFlotte();

    Task<Flotta> CreateFlotta(string nome);
    Task<Volo?> GetVoloByIdVolo (long idVolo);
    Task<Volo?> AddVolo (long aereoId, int postiResidui, double costoPosto, string partenza, string destinazione, DateTime orarioPartenza, DateTime orarioDestinazione);
    Task DeleteVoloByIdVolo (long idVolo);
    Task<Volo?> UpdateVoloByIdVolo (long idVolo, long aereoId, int postiResidui, double costoPosto, string partenza, string destinazione, DateTime orarioPartenza, DateTime orarioDestinazione);
    Task<List<Volo>> GetListaVoli ();
    Task<Biglietto?> GetBigliettoByIdBiglietto (long idBiglietto);
    Task<Biglietto?> AddBiglietto (long voloId, int numeroPostiRichiesti, double importoTotale, DateTime dataAcquisto);
    Task<List<Biglietto?>> GetBigliettoByIdVolo (long idVolo);
    Task DeleteBigliettoByIdBiglietto (long idBiglietto);
    Task DeleteTuttoVoloAndBiglietti(long Voloid);

}
