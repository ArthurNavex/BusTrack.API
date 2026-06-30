namespace BusTrack.Api.Models.Usuario;
using System.ComponentModel.DataAnnotations;

public class UsuarioResponse
{
    public int Id {get; set;}
    public string Nome {get; set;} = String.Empty;
}