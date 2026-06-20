namespace BusTrack.Api.Entitys;

public class Favorito {

    public int Id {get; set;}
    public int UsuarioId {get; set;}
    public int LinhaId {get; set;}
    public Usuario Usuario {get; set;}
    public Linha Linha {get; set;}
}