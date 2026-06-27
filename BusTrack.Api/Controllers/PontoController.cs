using BusTrack.Api.Data;
using BusTrack.Api.Entitys;
using BusTrack.Api.Models.Ponto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusTrack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PontosController : ControllerBase {

    private readonly BusTrackContext _context;

    public PontosController (BusTrackContext context) {

        _context = context;
    }

    [HttpPost]
    public IActionResult Post (CreatePontoRequest request) {

        var PontoCriado = new Ponto {

            Nome = request.Nome,
            Latitude = request.Latitude,
            Longitude = request.Longitude
        };

        _context.Pontos.Add(PontoCriado);
        _context.SaveChanges();

        return Ok(PontoCriado);
    }

    [HttpGet]
    public IActionResult Get() {

        var pontos = _context.Pontos.ToList();
        var response = new List<PontoResponse>();

        if (pontos == null) {

            return NotFound();
        }

        foreach (var ponto in pontos) {
            response.Add(new PontoResponse{

                Id = ponto.Id,
                Nome = ponto.Nome,
                Latitude = ponto.Latitude,
                Longitude = ponto.Longitude
            });
        }

        return Ok(response);
    }

    [HttpGet("{id}")]
    public IActionResult GetIndice(int id) {

        var ponto = _context.Pontos.FirstOrDefault(ponto => ponto.Id == id);

        if (ponto == null) {
            return NotFound();
        }

        var response = new PontoResponse {

            Id = ponto.Id,
            Nome = ponto.Nome,
            Latitude = ponto.Latitude,
            Longitude = ponto.Longitude
        };

        return Ok(response);
    }

    [HttpPut("{id}")]
    public IActionResult Update(UpdatePontoRequest request, int id) {

        var ponto = _context.Pontos.FirstOrDefault(ponto => ponto.Id == id);

        if (ponto == null) {
            return NotFound();
        }

        ponto.Nome = request.Nome;
        ponto.Latitude = request.Latitude;
        ponto.Longitude = request.Longitude;

        var response = new PontoResponse {

            Id = ponto.Id,
            Nome = ponto.Nome,
            Latitude = ponto.Latitude,
            Longitude = ponto.Longitude
        };

        _context.SaveChanges();

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) {

        var ponto = _context.Pontos.FirstOrDefault(ponto => ponto.Id == id);

        if (ponto == null) {
            return NotFound();
        }

        _context.Pontos.Remove(ponto);
        _context.SaveChanges();

        return NoContent();
    }
}