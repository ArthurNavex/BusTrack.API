namespace BusTrack.Api.Models.Trajeto;
using System.ComponentModel.DataAnnotations;
using BusTrack.Api.Models.Linha;

public class TrajetoResponse {

    public int Id {get; set;}
    public int LinhaId{get; set;}
    public int PontoId{get; set;}
    public int Ordem{get; set;}
    public string NomeLinha {get; set;} = String.Empty;
    public string NomePonto {get; set;} = String.Empty;
}