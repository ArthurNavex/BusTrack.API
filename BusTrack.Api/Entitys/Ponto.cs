namespace BusTrack.Api.Entitys;

public class Ponto {
    public int Id { get; set; }
    public required string Nome { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
}