using Microsoft.EntityFrameworkCore;

namespace Matheus.models;

public class AppDataContext : DbContext
{
    public DbSet<Funcionario> Funcionarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=matheus.db");
    }
}