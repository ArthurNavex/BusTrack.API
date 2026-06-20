namespace BusTrack.Api.Entitys;

public class Usuario {

    public int Id {get; set;}
    public required string Nome {get; set;}
    public List<Favorito> Favoritos;
}