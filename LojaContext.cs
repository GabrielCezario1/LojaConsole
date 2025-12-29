using Microsoft.EntityFrameworkCore;

public class LojaContext : DbContext
{
    // CAMINHÃO DE TRANSPORTE (DbSet)
    // Dizemos ao banco: "Quero que você guarde objetos do tipo Produto"
    public DbSet<Produto> Produtos { get; set; }

    // CONFIGURAÇÃO DA PONTE
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // ⚠️ ATENÇÃO: Troque '1234' pela senha que você criou na instalação do MySQL!
        // Connection String: Onde fica a casa e qual a chave da porta.
        optionsBuilder.UseMySql("server=localhost;database=LojaProjeto1;user=root;password=root", 
            new MySqlServerVersion(new Version(8, 0, 21)));
    }
}