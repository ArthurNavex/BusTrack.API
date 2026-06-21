using Microsoft.EntityFrameworkCore;
using BusTrack.Api.Entitys;

namespace BusTrack.Api.Data;

public class BusTrackContext : DbContext
{
    public BusTrackContext(DbContextOptions<BusTrackContext> options) : base(options) {

    }

    DbSet<Usuario> Usuarios {get; set;}
    DbSet<Linha> Linhas {get; set;}
    DbSet<Ponto> Pontos {get; set;}
    DbSet<Trajeto> Trajetos {get; set;}
    DbSet<Favorito> Favoritos {get; set;}
}