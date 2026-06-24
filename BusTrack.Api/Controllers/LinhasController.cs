using BusTrack.Api.Data;
using BusTrack.Api.Entitys;
using BusTrack.Api.Models.Linha;
using Microsoft.AspNetCore.Mvc;

namespace BusTrack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LinhasController : ControllerBase {

    private readonly BusTrackContext _context;

    public LinhasController(BusTrackContext context) {
        _context = context;
    }

    [HttpPost]
    public IActionResult Post (CreateLinhaRequest request) {

        var LinhaCriada = new Linha {

            Numero = request.Numero,
            Nome = request.Nome
        };

        _context.Linhas.Add(LinhaCriada);
        _context.SaveChanges();

        return Ok(LinhaCriada);
    }

    [HttpGet]
    public IActionResult Get () {

        var linhas = _context.Linhas.ToList();
        var response = new List<LinhaResponse>();

        foreach (var linha in linhas) {

            response.Add(new LinhaResponse{
                Id = linha.Id,
                Nome = linha.Nome,
                Numero = linha.Numero
            });
        }

        return Ok(response);
    }
}