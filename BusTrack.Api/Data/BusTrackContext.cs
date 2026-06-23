using Microsoft.EntityFrameworkCore;
using BusTrack.Api.Entitys;

namespace BusTrack.Api.Data;

public class BusTrackContext : DbContext
{
    public BusTrackContext(DbContextOptions<BusTrackContext> options) : base(options) {

    }

    public DbSet<Usuario> Usuarios {get; set;}
    public DbSet<Linha> Linhas {get; set;}
    public DbSet<Ponto> Pontos {get; set;}
    public DbSet<Trajeto> Trajetos {get; set;}
    public DbSet<Favorito> Favoritos {get; set;}
}