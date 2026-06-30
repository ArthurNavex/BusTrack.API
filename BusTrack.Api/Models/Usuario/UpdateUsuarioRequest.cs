namespace BusTrack.Api.Models.Usuario;
using System.ComponentModel.DataAnnotations;

public class UpdateUsuarioRequest
{
    [Required(ErrorMessage = "É nescessario colocar um nome.")]
    [StringLength(100, ErrorMessage = "O nome deve ter no maximo 100 caracteres.")]
    public string Nome {get; set;} = String.Empty;
}