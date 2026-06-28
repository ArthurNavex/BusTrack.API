namespace BusTrack.Api.Models.Trajeto;
using System.ComponentModel.DataAnnotations;

public class UpdateTrajetoRequest {

    [Range(1, int.MaxValue, ErrorMessage = "É necessário informar uma linha válida.")]
    public int LinhaId{get; set;}

    [Range(1, int.MaxValue, ErrorMessage = "É necessário informar um ponto válido.")]
    public int PontoId{get; set;}

    [Range(1, int.MaxValue, ErrorMessage = "A ordem tem que ser maior que zero.")]
    public int Ordem{get; set;}
}