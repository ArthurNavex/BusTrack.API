namespace BusTrack.Api.Models.Ponto;

public class PontoResponse {

    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public decimal Latitude {get; set;}
    public decimal Longitude {get; set;}
}