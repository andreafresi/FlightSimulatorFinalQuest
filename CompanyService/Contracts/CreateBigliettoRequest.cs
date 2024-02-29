namespace CompanyService;

public class CreateBigliettoRequest{
    public long BigliettoId{get;set;}
    public int NumPostReq { get; set; }
    public int VoloId { get; set; }
    public CreateBigliettoRequest(long bigliettoId, int numPostReq, int voloId)
    {
        BigliettoId = bigliettoId;
        NumPostReq = numPostReq;
        VoloId = voloId;
    }
}