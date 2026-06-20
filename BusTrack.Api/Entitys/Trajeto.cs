namespace BusTrack.Api.Entitys;

public class Trajeto {
    public int Id { get; set; }
    public int LinhaId { get; set; }
    public int PontoId { get; set; }
    public int Ordem {get; set;}
    public required Linha Linha { get; set; }
    public required Ponto Ponto {get; set;}
}