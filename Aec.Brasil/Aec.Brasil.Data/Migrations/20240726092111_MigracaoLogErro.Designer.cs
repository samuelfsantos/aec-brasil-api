﻿// <auto-generated />
using System;
using Aec.Brasil.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aec.Brasil.Data.Migrations
{
    [DbContext(typeof(AecBrasilContext))]
    [Migration("20240726092111_MigracaoLogErro")]
    partial class MigracaoLogErro
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("AecBrasil")
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Aec.Brasil.Domain.Entities.Aeroporto", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdAeroporto");

                    b.Property<DateTime?>("AlteradoEm")
                        .HasColumnType("datetime");

                    b.Property<string>("AlteradoPor")
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("CodigoIcao")
                        .IsRequired()
                        .HasMaxLength(4)
                        .IsUnicode(false)
                        .HasColumnType("varchar(4)");

                    b.Property<string>("Condicao")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2)");

                    b.Property<string>("CondicaoDesc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.Property<int>("DirecaoVento")
                        .HasColumnType("int");

                    b.Property<int>("PressaoAtmosferica")
                        .HasColumnType("int");

                    b.Property<int>("Temp")
                        .HasColumnType("int");

                    b.Property<int>("Umidade")
                        .HasColumnType("int");

                    b.Property<int>("Vento")
                        .HasColumnType("int");

                    b.Property<string>("Visibilidade")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("CodigoIcao")
                        .HasDatabaseName("IDX_Aeroporto_CodigoIcao");

                    b.ToTable("Aeroporto", "AecBrasil");
                });

            modelBuilder.Entity("Aec.Brasil.Domain.Entities.Cidade", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdCidade");

                    b.Property<DateTime?>("AlteradoEm")
                        .HasColumnType("datetime");

                    b.Property<string>("AlteradoPor")
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2)");

                    b.Property<int>("IdIntegracao")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("IdIntegracao")
                        .HasDatabaseName("IDX_Cidade_IdIntegracao");

                    b.ToTable("Cidade", "AecBrasil");
                });

            modelBuilder.Entity("Aec.Brasil.Domain.Entities.Clima", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdClima");

                    b.Property<DateTime?>("AlteradoEm")
                        .HasColumnType("datetime");

                    b.Property<string>("AlteradoPor")
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Condicao")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("varchar(2)");

                    b.Property<string>("CondicaoDesc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdCidade")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IndiceUV")
                        .HasColumnType("int");

                    b.Property<int>("Max")
                        .HasColumnType("int");

                    b.Property<int>("Min")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCidade")
                        .HasDatabaseName("FKIDX_Clima_Cidade");

                    b.ToTable("Clima", "AecBrasil");
                });

            modelBuilder.Entity("Aec.Brasil.Domain.Entities.LogErro", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdLogErro");

                    b.Property<DateTime?>("AlteradoEm")
                        .HasColumnType("datetime");

                    b.Property<string>("AlteradoPor")
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasMaxLength(80)
                        .IsUnicode(false)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5000)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("StackTrace")
                        .IsRequired()
                        .HasMaxLength(15000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("LogErro", "AecBrasil");
                });

            modelBuilder.Entity("Aec.Brasil.Domain.Entities.Clima", b =>
                {
                    b.HasOne("Aec.Brasil.Domain.Entities.Cidade", "Cidade")
                        .WithMany("Climas")
                        .HasForeignKey("IdCidade")
                        .IsRequired()
                        .HasConstraintName("FK_Clima_Cidade");

                    b.Navigation("Cidade");
                });

            modelBuilder.Entity("Aec.Brasil.Domain.Entities.Cidade", b =>
                {
                    b.Navigation("Climas");
                });
#pragma warning restore 612, 618
        }
    }
}
