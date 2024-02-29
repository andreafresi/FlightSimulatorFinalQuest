namespace CompanyService;

public class UpdateVoloRequest
{
    public long VoloId {get;set;}
    public long AereoId { get; set; }
    public int PostiResidui {get;set;}
    public double CostoPosto {get;set;}
    public string Partenza {get;set;}
    public string Destinazione {get;set;}
    public DateTime OrarioPartenza {get;set;}
    public DateTime OrarioDestinazione {get;set;}
    
    public UpdateVoloRequest(long voloId,long aereoId,int postiresidui, double costoposto,
                string partenza,string destinazione, DateTime orariopartenza,DateTime orariodestinazione)
    {
        VoloId = voloId;
        AereoId = aereoId;
        PostiResidui = postiresidui;
        CostoPosto =  costoposto;
        Partenza = partenza;
        Destinazione = destinazione;
        OrarioPartenza = orariopartenza;
        OrarioDestinazione = orariodestinazione;
    }
}
