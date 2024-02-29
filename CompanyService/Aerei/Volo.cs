namespace CompanyService;

public class Volo
{

    public long VoloId {get;set;}
    public long AereoId { get; set; }
    public int PostiResidui {get;set;}
    public double CostoPosto {get;set;}
    public string Partenza {get;set;}
    public string Destinazione {get;set;}
    public DateTime OrarioPartenza {get;set;}
    public DateTime OrarioDestinazione {get;set;}

    public Volo()
    {

    }
    public Volo(long voloId,long aereoId,int postiresidui, double costoposto,
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
    public Volo(long aereoId,int postiresidui, double costoposto,
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
    
    public void UpdateInformazioniVolo(long aereoId,int postiresidui, double costoposto,
                string partenza,string destinazione, DateTime orariopartenza,DateTime orariodestinazione)
    { 
        this.AereoId = aereoId;
        this.PostiResidui = postiresidui;
        this.CostoPosto =  costoposto;
        this.Partenza = partenza;
        this.Destinazione = destinazione;
        this.OrarioPartenza = orariopartenza;
        this.OrarioDestinazione = orariodestinazione;

    }
    
    public Volo? GetVoloById(long idAereo)
    {
       return null;
    }
    
}
