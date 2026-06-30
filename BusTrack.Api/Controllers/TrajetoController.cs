using BusTrack.Api.Data;
using BusTrack.Api.Entitys;
using BusTrack.Api.Models.Ponto;
using BusTrack.Api.Models.Trajeto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusTrack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrajetoController : ControllerBase
{
    private readonly BusTrackContext _context;

    public TrajetoController(BusTrackContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult Post(CreatTrajetoRequest request)
    {
        var linha = _context.Linhas.FirstOrDefault(linha => linha.Id == request.LinhaId);
        var ponto = _context.Pontos.FirstOrDefault(ponto => ponto.Id == request.PontoId);
        var ordemExiste = _context.Trajetos.Any(trajeto =>
            trajeto.LinhaId == request.LinhaId && trajeto.Ordem == request.Ordem
        );

        if (linha == null)
        {
            return NotFound("Linha não encontrada.");
        } 
        if (ponto == null)
        {
            return NotFound("Ponto não encontrado.");
        } 

        if (ordemExiste)
        {
            return BadRequest("Já existe um ponto nessa ordem para essa linha.");
        }

        var TrajetoCriado = new Trajeto
        {
            LinhaId = request.LinhaId,
            PontoId = request.PontoId,
            Ordem = request.Ordem,
            Linha = linha,
            Ponto = ponto,
        };
        
        var response = new TrajetoResponse
        {
            LinhaId = request.LinhaId,
            PontoId = request.PontoId,
            Ordem = request.Ordem,
            NomeLinha = linha.Nome,
            NomePonto = ponto.Nome

        };

        _context.Trajetos.Add(TrajetoCriado);
        _context.SaveChanges();
        
        return Ok(response);      
    }

    [HttpGet]
    public IActionResult Get()
    {
        var trajetos = _context.Trajetos.Include(trajeto => trajeto.Linha).Include(trajeto => trajeto.Ponto).ToList();
        var response = new List<TrajetoResponse>();

        foreach(var trajeto in trajetos)
        {
            response.Add(new TrajetoResponse
            {
                Id = trajeto.Id,
                LinhaId = trajeto.LinhaId,
                PontoId = trajeto.PontoId,
                Ordem = trajeto.Ordem,
                NomeLinha = trajeto.Linha.Nome,
                NomePonto = trajeto.Ponto.Nome
            });
        }

        return Ok(response);
    }

    [HttpGet ("{Id}")]
    public IActionResult GetIndice(int Id)
    {
        var trajeto = _context.Trajetos.Include(trajeto => trajeto.Linha).Include(trajeto => trajeto.Ponto)
        .FirstOrDefault(trajeto => trajeto.Id == Id);

        if (trajeto == null)
        {
            return NotFound();
        }

        var response = new TrajetoResponse
        {
            Id = trajeto.Id,
            LinhaId = trajeto.LinhaId,
            PontoId = trajeto.PontoId,
            Ordem = trajeto.Ordem,
            NomeLinha = trajeto.Linha.Nome,
            NomePonto = trajeto.Ponto.Nome,
        };


        return Ok(response);
    }

    [HttpPut ("{id}")]
    public IActionResult Put(int id, UpdateTrajetoRequest request)
    {
        var trajeto = _context.Trajetos.Include(trajeto => trajeto.Linha).Include(trajeto => trajeto.Ponto)
        .FirstOrDefault(trajeto => trajeto.Id == id);

        var trajetoExiste = _context.Trajetos.Any(trajeto => trajeto.LinhaId == request.LinhaId && trajeto.PontoId == request.PontoId
        && trajeto.Id != id);
        var ordemExiste = _context.Trajetos.Any(trajeto =>
            trajeto.LinhaId == request.LinhaId && trajeto.Ordem == request.Ordem
        );

        if(trajeto == null)
        {
            return NotFound();
        }

        if (ordemExiste)
        {
            return BadRequest("Já existe um ponto nessa ordem para essa linha.");
        }


        if (trajetoExiste)
        {
            return BadRequest("Este trajeto já existe");
        }

        trajeto.LinhaId = request.LinhaId;
        trajeto.PontoId = request.PontoId;
        trajeto.Ordem = request.Ordem;

        _context.SaveChanges();

        var response = new TrajetoResponse
        {
            Id = trajeto.Id,
            LinhaId = trajeto.LinhaId,
            PontoId = trajeto.PontoId,
            Ordem = trajeto.Ordem,
            NomeLinha = trajeto.Linha.Nome,
            NomePonto = trajeto.Ponto.Nome
        };

        return Ok(response);
    }

    [HttpDelete ("{id}")]
    public IActionResult Delete (int id)
    {
        var trajeto = _context.Trajetos.FirstOrDefault(trajeto => trajeto.Id == id);

        if (trajeto == null)
        {
            return NotFound();
        }

        _context.Trajetos.Remove(trajeto);
        _context.SaveChanges();


        return NoContent();
    }
}