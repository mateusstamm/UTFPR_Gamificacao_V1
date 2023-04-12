using UTFPR_Gamificacao_V1.RazorPages.Models;

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UTFPR_Gamificacao_V1.RazorPages.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // Cria o banco de dados e aplica as migrações pendentes
            context.Database.EnsureCreated();

            // Verifica se já existem registros nas tabelas
            if (!context.Produtos!.Any() || 
                !context.Categorias!.Any() || 
                !context.Mesas!.Any() || 
                !context.Garcons!.Any() || 
                !context.ProdutosAtendimentos!.Any() ||
                !context.Atendimentos!.Any())
            {
                return;   // Banco de dados já foi inicializado
            }

            // Cria categorias
            var categorias = new CategoriaModel[]
            {
                new CategoriaModel{ Nome="Bebidas", Descricao="Bebidas diversas" },
                new CategoriaModel{ Nome="Entradas", Descricao="Entradas variadas" },
                new CategoriaModel{ Nome="Pratos principais", Descricao="Pratos principais quentes" },
                new CategoriaModel{ Nome="Sobremesas", Descricao="Sobremesas deliciosas" }
            };
            foreach (CategoriaModel c in categorias)
            {
                context.Categorias?.Add(c);
            }

            // Cria produtos
            var produtos = new ProdutoModel[]
            {
                new ProdutoModel{ Nome="Coca-cola", Descricao="Refrigerante de cola", Preco=4.50m, Categoria=categorias[0] },
                new ProdutoModel{ Nome="Pastel", Descricao="Pastel de carne", Preco=5.00m, Categoria=categorias[1] },
                new ProdutoModel{ Nome="Lasanha", Descricao="Lasanha de frango", Preco=20.00m, Categoria=categorias[2] },
                new ProdutoModel{ Nome="Pudim", Descricao="Pudim de leite", Preco=8.00m, Categoria=categorias[3] }
            };
            foreach (ProdutoModel p in produtos)
            {
                context.Produtos?.Add(p);
            }

            // Cria garçons
            var garcons = new GarconModel[]
            {
                new GarconModel{ Nome="João", Sobrenome="Silva", Identificacao=1.ToString(), NumeroTelefone="(11) 99999-1111" },
                new GarconModel{ Nome="Maria", Sobrenome="Santos", Identificacao=2.ToString(), NumeroTelefone="(11) 99999-2222" }
            };
            foreach (GarconModel g in garcons)
            {
                context.Garcons?.Add(g);
            }

            // Cria mesas
            var mesas = new MesaModel[]
            {
                new MesaModel{ Numero=1, Status="Livre" },
                new MesaModel{ Numero=2, Status="Livre" },
                new MesaModel{ Numero=3, Status="Livre" }
            };
            foreach (MesaModel m in mesas)
            {
                context.Mesas?.Add(m);
            }

            // Cria um atendimento
            var atendimento = new AtendimentoModel
            {
                Garcon = garcons[0],
                Mesa = mesas[0],
                HoraPedido = DateTime.Now,
            };
            context.Atendimentos?.Add(atendimento);

            // Adiciona produtos ao atendimento
            var produtoAtendimento = new ProdutoAtendimentoModel
            {
                Atendimento = atendimento,
                Produto = produtos[0],
                Quantidade = 2
            };
            context.ProdutosAtendimentos?.Add(produtoAtendimento);

            context.SaveChanges();
        }
    }
}