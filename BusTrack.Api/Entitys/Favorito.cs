namespace BusTrack.Api.Entitys;

public class Favorito {

    public int Id {get; set;}
    public int UsuarioId {get; set;}
    public int LinhaId {get; set;}
    public required Usuario Usuario {get; set;} 
    public required Linha Linha {get; set;}
}