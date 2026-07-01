using BusTrack.Api.Data;
using BusTrack.Api.Entitys;
using BusTrack.Api.Models.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusTrack.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly BusTrackContext _context;

    public UsuarioController (BusTrackContext context) {
        _context = context;
    }

    [HttpPost]
    public IActionResult Post(CreateUsuarioRequest request)
    {
        var UsuarioCriado = new Usuario
        {
            Nome = request.Nome
        };

        var response = new UsuarioResponse
        {
            Nome = UsuarioCriado.Nome
        };

        _context.Usuarios.Add(UsuarioCriado);
        _context.SaveChanges();

        return Ok(response);
    }

    [HttpGet]
    public IActionResult Get()
    {
        var usuarios = _context.Usuarios.ToList();
        var response = new List<UsuarioResponse>();

        if(usuarios == null)
        {
            return NotFound();
        }

        foreach(var usuario in usuarios)
        {
            response.Add(new UsuarioResponse
            {
               Id = usuario.Id,
               Nome = usuario.Nome 
            });
        }

        return Ok(response);
    }

    [HttpGet ("{id}")]
    public IActionResult GetIndice(int id)
    {
        var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);

        if (usuario == null)
        {
            return NotFound();
        }

        var response = new UsuarioResponse
        {
            Id = usuario.Id,
            Nome = usuario.Nome
        };

        return Ok(response);
    }

    [HttpPut ("{id}")]
    public IActionResult Put (int id, UpdateUsuarioRequest request)
    {
        var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);

        if(usuario == null)
        {
            return NotFound();
        }

        usuario.Nome = request.Nome;
        
        _context.SaveChanges();

        var response = new UsuarioResponse
        {
            Nome = usuario.Nome
        };

        return Ok(response);
    }

    [HttpDelete ("{id}")]
    public IActionResult Delete(int id)
    {
        var usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Id == id);

         if(usuario == null)
        {
            return NotFound();
        }

        _context.Usuarios.Remove(usuario);
        _context.SaveChanges();

        return NoContent();
    }
}