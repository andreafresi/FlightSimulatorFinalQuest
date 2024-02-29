namespace CompanyService;

public class Biglietto
{
    // aggiungere il GET della classe intera, che ritorna tutta la classe 
    public long BigliettoId  { get; set; }
    public long VoloId { get; set; } // esiste già, ma si riscrive
    public int NumeroPostiRichiesti { get; set; } // può avere più persone in un unico 
    public double ImportoTotale { get; set; } // importo singolo X numero postiRichiesti
    public DateTime DataAcquisto { get; set; }

    public Biglietto()
    {      
    }

    public Biglietto(long voloId, int numeroPostiRichiesti, double importoTotale, DateTime dataAcquisto)
    {
        VoloId = voloId;
        NumeroPostiRichiesti = numeroPostiRichiesti;
        ImportoTotale = importoTotale;
        DataAcquisto = dataAcquisto;        
    }

    public Biglietto(long bigliettoId, long voloId, int numeroPostiRichiesti, double importoTotale, DateTime dataAcquisto)
    {
        BigliettoId = bigliettoId;
        VoloId = voloId;
        NumeroPostiRichiesti = numeroPostiRichiesti;
        ImportoTotale = importoTotale;
        DataAcquisto = dataAcquisto;        
    }

    public void UpdateBiglietto(int numeroPostiRichiesti, DateTime dataAcquisto) // un Modifica???
    {
        this.NumeroPostiRichiesti = numeroPostiRichiesti;
        this.DataAcquisto = dataAcquisto;
    }

/*  // DA METTTERE NEL PROGRAM
    Biglietto b1 = new Biglietto(v1.VoloId, 17, 150.2, new DateTime(2024-3-29-9-10-11));
    db.Biglietto.Add(b1);
    Biglietto b2 = new Biglietto(v2.VoloId, 2, 25.70, new DateTime(2020-1-13-8-9-10));
    db.Biglietto.Add(b2); 
*/

}
