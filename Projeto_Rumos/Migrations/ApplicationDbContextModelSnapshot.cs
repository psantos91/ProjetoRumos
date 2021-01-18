﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2.Data;

namespace Projeto_Rumos.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Models.CarrinhoCompra", b =>
                {
                    b.Property<int>("CarrinhoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CarrinhoId");

                    b.HasIndex("ProdutoId")
                        .IsUnique();

                    b.ToTable("CarrinhoCompras");
                });

            modelBuilder.Entity("Models.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            CategoriaId = 1,
                            Nome = "Frutas"
                        },
                        new
                        {
                            CategoriaId = 2,
                            Nome = "Legumes"
                        });
                });

            modelBuilder.Entity("Models.Encomenda", b =>
                {
                    b.Property<int>("EncomendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int?>("IdCarrinhoCompra")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EncomendaId");

                    b.HasIndex("IdCarrinhoCompra");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Encomendas");
                });

            modelBuilder.Entity("Models.EncomendaProduto", b =>
                {
                    b.Property<int>("EncomendaId")
                        .HasColumnType("int");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("EncomendaId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("EncomendaProduto");
                });

            modelBuilder.Entity("Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FuncaoEmpregado")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("NumeroDeTrabalhador")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("Models.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<string>("ImageMimeType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Preco")
                        .HasColumnType("real");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ProdutoId");

                    b.HasIndex("IdCategoria");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            ProdutoId = 1,
                            Descricao = "Banana importada da Colombia.",
                            IdCategoria = 1,
                            ImageMimeType = "image/jpeg",
                            Nome = "Banana",
                            PhotoFileName = "banana1.jpg",
                            Preco = 0.99f,
                            Stock = 10
                        },
                        new
                        {
                            ProdutoId = 2,
                            Descricao = "Clementina natural de Portugal",
                            IdCategoria = 1,
                            ImageMimeType = "image/jpeg",
                            Nome = "Clementina",
                            PhotoFileName = "clementina.jpg",
                            Preco = 0.79f,
                            Stock = 100
                        },
                        new
                        {
                            ProdutoId = 3,
                            Descricao = "Maça fuji, importada",
                            IdCategoria = 1,
                            ImageMimeType = "image/jpeg",
                            Nome = "Maça Fuji",
                            PhotoFileName = "fuji.jpg",
                            Preco = 0.59f,
                            Stock = 150
                        },
                        new
                        {
                            ProdutoId = 4,
                            Descricao = "Kiwi, directamente da nossa quinta",
                            IdCategoria = 1,
                            ImageMimeType = "image/jpeg",
                            Nome = "Kiwi",
                            PhotoFileName = "kiwi.jpg",
                            Preco = 3.99f,
                            Stock = 300
                        },
                        new
                        {
                            ProdutoId = 5,
                            Descricao = "O melhor limão de Portugal",
                            IdCategoria = 1,
                            ImageMimeType = "image/jpeg",
                            Nome = "Limão",
                            PhotoFileName = "limao-siciliano.jpg",
                            Preco = 0.99f,
                            Stock = 150
                        },
                        new
                        {
                            ProdutoId = 6,
                            Descricao = "O melhor melão. Importado do Brasil",
                            IdCategoria = 1,
                            ImageMimeType = "image/jpeg",
                            Nome = "Melão",
                            PhotoFileName = "melao.jpg",
                            Preco = 1.99f,
                            Stock = 200
                        },
                        new
                        {
                            ProdutoId = 7,
                            Descricao = "Pera natural, diretamente da nossa quinta",
                            IdCategoria = 1,
                            ImageMimeType = "image/jpeg",
                            Nome = "Peras",
                            PhotoFileName = "peras.jpg",
                            Preco = 0.99f,
                            Stock = 200
                        },
                        new
                        {
                            ProdutoId = 8,
                            Descricao = "Uva do Alentejo",
                            IdCategoria = 1,
                            ImageMimeType = "image/jpeg",
                            Nome = "Uva",
                            PhotoFileName = "uvas.jpg",
                            Preco = 1.29f,
                            Stock = 300
                        });
                });

            modelBuilder.Entity("Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CartaoIdentificacao")
                        .HasColumnType("int");

                    b.Property<int>("Contacto")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Morada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SobreNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            UsuarioId = 1,
                            CartaoIdentificacao = 123123123,
                            Contacto = 919335544,
                            DataNascimento = new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "joaogoncalves@gmail.com",
                            Morada = "Rua A, Nr. 1",
                            Nome = "Joao",
                            Password = "password1",
                            SobreNome = "Goncalves",
                            Username = "jgoncalves1"
                        },
                        new
                        {
                            UsuarioId = 2,
                            CartaoIdentificacao = 231231231,
                            Contacto = 914586522,
                            DataNascimento = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "joaomachado@gmail.com",
                            Morada = "Rua B, Nr. 2",
                            Nome = "Joao",
                            Password = "password2",
                            SobreNome = "Machado",
                            Username = "jmachado2"
                        },
                        new
                        {
                            UsuarioId = 3,
                            CartaoIdentificacao = 456456456,
                            Contacto = 914588541,
                            DataNascimento = new DateTime(1991, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "paulosantos@gmail.com",
                            Morada = "Rua C, Nr. 3",
                            Nome = "Paulo",
                            Password = "password3",
                            SobreNome = "Santos",
                            Username = "psantos3"
                        },
                        new
                        {
                            UsuarioId = 4,
                            CartaoIdentificacao = 789789789,
                            Contacto = 915663244,
                            DataNascimento = new DateTime(1991, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "pedromartins@gmail.com",
                            Morada = "Rua D, Nr. 4",
                            Nome = "Pedro",
                            Password = "password4",
                            SobreNome = "Martins",
                            Username = "pmartins4"
                        });
                });

            modelBuilder.Entity("Models_Class.Pagamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CarrihoCompraCarrinhoId")
                        .HasColumnType("int");

                    b.Property<int>("CarrinhoId")
                        .HasColumnType("int");

                    b.Property<int>("EncomendaId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarrihoCompraCarrinhoId");

                    b.HasIndex("EncomendaId");

                    b.ToTable("Pagamentos");
                });

            modelBuilder.Entity("Projeto_Rumos.Areas.Identity.Pages.Account.UserData.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SobreNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Projeto_Rumos.Areas.Identity.Pages.Account.UserData.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Projeto_Rumos.Areas.Identity.Pages.Account.UserData.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto_Rumos.Areas.Identity.Pages.Account.UserData.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Projeto_Rumos.Areas.Identity.Pages.Account.UserData.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.CarrinhoCompra", b =>
                {
                    b.HasOne("Models.Produto", "Produto")
                        .WithOne("Carrinho")
                        .HasForeignKey("Models.CarrinhoCompra", "ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Models.Encomenda", b =>
                {
                    b.HasOne("Models.CarrinhoCompra", "CarrinhoCompra")
                        .WithMany()
                        .HasForeignKey("IdCarrinhoCompra");

                    b.HasOne("Models.Usuario", "Usuario")
                        .WithMany("Encomendas")
                        .HasForeignKey("IdUsuario");

                    b.Navigation("CarrinhoCompra");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Models.EncomendaProduto", b =>
                {
                    b.HasOne("Models.Encomenda", "Encomenda")
                        .WithMany("EncomendaProdutos")
                        .HasForeignKey("EncomendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Produto", "Produto")
                        .WithMany("EncomendaProdutos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Encomenda");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Models.Produto", b =>
                {
                    b.HasOne("Models.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("IdCategoria");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Models_Class.Pagamento", b =>
                {
                    b.HasOne("Models.CarrinhoCompra", "CarrihoCompra")
                        .WithMany()
                        .HasForeignKey("CarrihoCompraCarrinhoId");

                    b.HasOne("Models.Encomenda", "Encomenda")
                        .WithMany()
                        .HasForeignKey("EncomendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarrihoCompra");

                    b.Navigation("Encomenda");
                });

            modelBuilder.Entity("Models.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("Models.Encomenda", b =>
                {
                    b.Navigation("EncomendaProdutos");
                });

            modelBuilder.Entity("Models.Produto", b =>
                {
                    b.Navigation("Carrinho");

                    b.Navigation("EncomendaProdutos");
                });

            modelBuilder.Entity("Models.Usuario", b =>
                {
                    b.Navigation("Encomendas");
                });
#pragma warning restore 612, 618
        }
    }
}
