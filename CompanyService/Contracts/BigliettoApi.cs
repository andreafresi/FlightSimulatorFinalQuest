namespace CompanyService;

public class BigliettoApi
{
    public long BigliettoId {get; set;}
    public long VoloId {get; set;}
    public int NumeroPostiRichiesti {get; set;}
    public double ImportoTotale {get; set;}
    public DateTime DataAcquisto {get; set;}

    public BigliettoApi(long bigliettoId, long voloId, int numeroPostiRichiesti, double importoTotale, DateTime dataAcquisto)
    {
        BigliettoId = bigliettoId;
        VoloId = voloId;
        NumeroPostiRichiesti = numeroPostiRichiesti;
        ImportoTotale = importoTotale;
        DataAcquisto = dataAcquisto;
    }

    public BigliettoApi BigliettoApiFactory (long bigliettoId, long voloId, int numeroPostiRichiesti, double importoTotale, DateTime dataAcquisto)
    {
        return new BigliettoApi (bigliettoId, voloId, numeroPostiRichiesti, importoTotale, dataAcquisto);
    }
}
