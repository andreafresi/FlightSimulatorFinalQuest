namespace CompanyService;

public class CreateBigliettoRequest{

    public int NumPostReq { get; set; }
    public int VoloId { get; set; }
    public CreateBigliettoRequest(int numPostReq, int voloId)
    {
        NumPostReq = numPostReq;
        VoloId = voloId;
    }
}