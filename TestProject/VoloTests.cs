using CompanyService;

namespace TestProject;

public class VoloTest
{
    [Fact]
    public void VerificaInizializzazioneId()
    {
        // ARRANGE
        long idVolo = 3;
        long idAereo = 13;
        int postiresidui = 21;
        double costoposto = 45.60;
        string partenza = "Rimini";
        string destinazione = "Londra";

        DateTime orarioPartenza = new DateTime (2024,3,16,10,30,0);
        DateTime orarioDestinazione = new DateTime (2024,3,16,12,20,0);

        // ACT
        var volo = new Volo(idVolo, idAereo, postiresidui, costoposto, partenza, destinazione, orarioPartenza, orarioDestinazione);

        // ASSERT
        Assert.Equal(idVolo, volo.VoloId);
        Assert.Equal(idAereo, volo.AereoId);        
        Assert.Equal(orarioDestinazione, volo.OrarioDestinazione);
    }
}
