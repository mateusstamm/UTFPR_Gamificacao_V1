﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UTFPR_Gamificacao_V1.RazorPages.Data;

#nullable disable

namespace UTFPR_Gamificacao_V1.RazorPages.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("UTFPR_Gamificacao_V1.RazorPages.Models.AtendimentoModel", b =>
                {
                    b.Property<int>("AtendimentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GarconId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("HoraPedido")
                        .HasColumnType("TEXT");

                    b.Property<int>("MesaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AtendimentoId");

                    b.HasIndex("GarconId");

                    b.HasIndex("MesaId");

                    b.ToTable("Atendimentos", (string)null);
                });

            modelBuilder.Entity("UTFPR_Gamificacao_V1.RazorPages.Models.CategoriaModel", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias", (string)null);
                });

            modelBuilder.Entity("UTFPR_Gamificacao_V1.RazorPages.Models.GarconModel", b =>
                {
                    b.Property<int>("GarconId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Identificacao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroTelefone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GarconId");

                    b.ToTable("Garcons", (string)null);
                });

            modelBuilder.Entity("UTFPR_Gamificacao_V1.RazorPages.Models.MesaModel", b =>
                {
                    b.Property<int>("MesaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("HoraAbertura")
                        .HasColumnType("TEXT");

                    b.Property<int>("Numero")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MesaId");

                    b.ToTable("Mesas", (string)null);
                });

            modelBuilder.Entity("UTFPR_Gamificacao_V1.RazorPages.Models.ProdutoAtendimentoModel", b =>
                {
                    b.Property<int>("AtendimentoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.HasKey("AtendimentoId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ProdutosAtendimentos", (string)null);
                });

            modelBuilder.Entity("UTFPR_Gamificacao_V1.RazorPages.Models.ProdutoModel", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Preco")
                        .HasColumnType("TEXT");

                    b.HasKey("ProdutoId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produtos", (string)null);
                });

            modelBuilder.Entity("UTFPR_Gamificacao_V1.RazorPages.Models.AtendimentoModel", b =>
                {
                    b.HasOne("UTFPR_Gamificacao_V1.RazorPages.Models.GarconModel", "Garcon")
                        .WithMany()
                        .HasForeignKey("GarconId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UTFPR_Gamificacao_V1.RazorPages.Models.MesaModel", "Mesa")
                        .WithMany()
                        .HasForeignKey("MesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Garcon");

                    b.Navigation("Mesa");
                });

            modelBuilder.Entity("UTFPR_Gamificacao_V1.RazorPages.Models.ProdutoAtendimentoModel", b =>
                {
                    b.HasOne("UTFPR_Gamificacao_V1.RazorPages.Models.AtendimentoModel", "Atendimento")
                        .WithMany("ProdutosAtendimento")
                        .HasForeignKey("AtendimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UTFPR_Gamificacao_V1.RazorPages.Models.ProdutoModel", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Atendimento");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("UTFPR_Gamificacao_V1.RazorPages.Models.ProdutoModel", b =>
                {
                    b.HasOne("UTFPR_Gamificacao_V1.RazorPages.Models.CategoriaModel", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("UTFPR_Gamificacao_V1.RazorPages.Models.AtendimentoModel", b =>
                {
                    b.Navigation("ProdutosAtendimento");
                });
#pragma warning restore 612, 618
        }
    }
}
