namespace BusTrack.Api.Models.Linha;
using System.ComponentModel.DataAnnotations;

public class UpdateLinhaRequest {

    [Required(ErrorMessage ="É nescessario informar o nome da linha!")]
    public string Nome {get; set;} = string.Empty;
    [Range(1, int.MaxValue, ErrorMessage = "O número da linha deve ser maior que zero.")]
    public int Numero {get; set;}
}
