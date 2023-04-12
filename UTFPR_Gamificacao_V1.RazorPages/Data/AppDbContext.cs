using UTFPR_Gamificacao_V1.RazorPages.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace UTFPR_Gamificacao_V1.RazorPages.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<MesaModel>? Mesas { get; set; }
        public DbSet<GarconModel>? Garcons { get; set; }
        public DbSet<CategoriaModel>? Categorias { get; set; }
        public DbSet<ProdutoModel>? Produtos { get; set; }
        public DbSet<AtendimentoModel>? Atendimentos { get; set; }
        public DbSet<ProdutoAtendimentoModel>? ProdutosAtendimentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            => options.UseSqlite("DataSource=database.db;Cache=Shared;");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais de mapeamento das entidades
            modelBuilder.Entity<MesaModel>().ToTable("Mesas");
            modelBuilder.Entity<MesaModel>().HasKey(m => m.MesaId);
            modelBuilder.Entity<MesaModel>().Property(m => m.Numero).IsRequired();
            modelBuilder.Entity<MesaModel>().Property(m => m.Status).IsRequired();
            modelBuilder.Entity<MesaModel>().Property(m => m.HoraAbertura).IsRequired(false);

            modelBuilder.Entity<GarconModel>().ToTable("Garcons");
            modelBuilder.Entity<GarconModel>().HasKey(g => g.GarconId);
            modelBuilder.Entity<GarconModel>().Property(g => g.Nome).IsRequired();
            modelBuilder.Entity<GarconModel>().Property(g => g.Sobrenome).IsRequired();
            modelBuilder.Entity<GarconModel>().Property(g => g.Identificacao).IsRequired();
            modelBuilder.Entity<GarconModel>().Property(g => g.NumeroTelefone).IsRequired(false);

            modelBuilder.Entity<CategoriaModel>().ToTable("Categorias");
            modelBuilder.Entity<CategoriaModel>().HasKey(c => c.CategoriaId);
            modelBuilder.Entity<CategoriaModel>().Property(c => c.Nome).IsRequired();
            modelBuilder.Entity<CategoriaModel>().Property(c => c.Descricao).IsRequired(false);

            modelBuilder.Entity<ProdutoModel>().ToTable("Produtos");
            modelBuilder.Entity<ProdutoModel>().HasKey(p => p.ProdutoId);
            modelBuilder.Entity<ProdutoModel>().Property(p => p.Nome).IsRequired();
            modelBuilder.Entity<ProdutoModel>().Property(p => p.Descricao).IsRequired(false);
            modelBuilder.Entity<ProdutoModel>().Property(p => p.Preco).IsRequired();

            modelBuilder.Entity<AtendimentoModel>().ToTable("Atendimentos");
            modelBuilder.Entity<AtendimentoModel>().HasKey(a => a.AtendimentoId);
            modelBuilder.Entity<AtendimentoModel>().Property(a => a.HoraPedido).IsRequired();
            //modelBuilder.Entity<AtendimentoModel>().HasOne(a => a.Mesa).WithMany(m => m.Atendimentos).HasForeignKey(a => a.MesaId);
            //modelBuilder.Entity<AtendimentoModel>().HasOne(a => a.Garcon).WithMany(g => g.Atendimentos).HasForeignKey(a => a.GarconId);

            modelBuilder.Entity<ProdutoAtendimentoModel>().ToTable("ProdutosAtendimentos");
            modelBuilder.Entity<ProdutoAtendimentoModel>().HasKey(pa => new { pa.AtendimentoId, pa.ProdutoId });
            modelBuilder.Entity<ProdutoAtendimentoModel>().Property(pa => pa.Quantidade).IsRequired();
            modelBuilder.Entity<ProdutoAtendimentoModel>().HasOne(pa => pa.Atendimento).WithMany(a => a.ProdutosAtendimento).HasForeignKey(pa => pa.AtendimentoId);
            //modelBuilder.Entity<ProdutoAtendimentoModel>().HasOne(pa => pa.Produto).WithMany(p => p.ProdutosAtendimento).HasForeignKey(pa => pa.ProdutoId);
        }
    }
}
