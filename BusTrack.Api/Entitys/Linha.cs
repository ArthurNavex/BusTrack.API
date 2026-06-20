namespace BusTrack.Api.Entitys;

public class Linha {
    public int Id { get; set; }
    public int Numero { get; set; }
    public required string Nome { get; set; }
    public List<Favorito> Favoritos {get; set;}
}