using CompanyService;

namespace TestProject;

public class BigliettoTest
{
    [Fact]
    public void VerificaInizializzazioneId()
    {
        // ARRANGE
        long idBiglietto = 1;
        long idVolo = 3;
        int numeroPostiRichiesti = 2;
        double importoTotale = 91.20;
        DateTime dataAcquisto = new DateTime (2024,3,11,17,49,0);

        // ACT
        var biglietto = new Biglietto(idBiglietto, idVolo, numeroPostiRichiesti, importoTotale, dataAcquisto);
        // ASSERT
        Assert.Equal(idBiglietto, biglietto.BigliettoId);
        Assert.Equal(idVolo, biglietto.VoloId);        
        Assert.Equal(dataAcquisto, biglietto.DataAcquisto);
    }
}
