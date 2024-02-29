namespace CompanyService;

public class VoloApi
{
    public long VoloId {get; set;}
    public long AereoId {get; set;}
    public int PostiResidui {get; set;}
    public double CostoPosto {get; set;}
    public string Partenza {get; set;}
    public string Destinazione {get; set;}
    public DateTime OrarioPartenza {get; set;}
    public DateTime OrarioDestinazione {get; set;}
    
    public VoloApi(long voloId, long aereoId, int postiResidui, double costoPosto, string partenza, 
                    string destinazione, DateTime orarioPartenza, DateTime orarioDestinazione)
    {
        VoloId = voloId;
        AereoId = aereoId;
        PostiResidui = postiResidui;
        CostoPosto = costoPosto;
        Partenza = partenza;
        Destinazione = destinazione;
        OrarioPartenza = orarioPartenza;
        OrarioDestinazione = orarioDestinazione;
    }
}
