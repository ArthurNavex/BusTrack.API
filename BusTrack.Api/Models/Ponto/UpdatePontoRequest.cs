namespace BusTrack.Api.Models.Ponto;
using System.ComponentModel.DataAnnotations;

public class UpdatePontoRequest {

    [Required(ErrorMessage ="É nescessario informar o nome do Ponto!")]
    public string Nome {get; set;} = String.Empty;
    
    [Required(ErrorMessage ="É necessário informar a latitude")]
    [Range(-90, 90, ErrorMessage ="A latitude deve estar entre -90 e 90")]
    public decimal Latitude {get; set;}

    [Required(ErrorMessage ="É necessário informar a longitude")]
    [Range(-180, 180, ErrorMessage ="A longitude deve estar entre -180 e 180")]
    public decimal Longitude {get; set;}
}