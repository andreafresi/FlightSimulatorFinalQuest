namespace CompanyService;

public class CreateVoloRequest
{
    public long AereoId { get; set; }
    public int PostiResidui {get;set;}
    public double CostoPosto {get;set;}
    public string Partenza {get;set;}
    public string Destinazione {get;set;}
    public DateTime OrarioPartenza {get;set;}
    public DateTime OrarioDestinazione {get;set;}
    
    public CreateVoloRequest(long aereoId,int postiresidui, double costoposto,
                string partenza,string destinazione, DateTime orariopartenza,DateTime orariodestinazione)
    {
        AereoId = aereoId;
        PostiResidui = postiresidui;
        CostoPosto =  costoposto;
        Partenza = partenza;
        Destinazione = destinazione;
        OrarioPartenza = orariopartenza;
        OrarioDestinazione = orariodestinazione;
    }
}
