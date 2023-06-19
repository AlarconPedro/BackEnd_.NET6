using System;
using System.Collections.Generic;
using API_Alunos.Models;
using API_Alunos.Models.Aluno;
using Microsoft.EntityFrameworkCore;

namespace API_Alunos.Context;

public partial class SouMaisFitContext : DbContext
{
    public SouMaisFitContext()
    {
    }

    public SouMaisFitContext(DbContextOptions<SouMaisFitContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAluno> TbAlunos { get; set; }

    public virtual DbSet<TbAlunoAtividade> TbAlunoAtividades { get; set; }

    public virtual DbSet<TbAlunoAtividadeImagem> TbAlunoAtividadeImagems { get; set; }

    public virtual DbSet<TbAlunoDesafio> TbAlunoDesafios { get; set; }

    public virtual DbSet<TbAlunoEvento> TbAlunoEventos { get; set; }

    public virtual DbSet<TbDesafio> TbDesafios { get; set; }

    public virtual DbSet<TbDesafioModalidade> TbDesafioModalidades { get; set; }

    public virtual DbSet<TbEvento> TbEventos { get; set; }

    public virtual DbSet<TbMedalha> TbMedalhas { get; set; }

    public virtual DbSet<TbMedalhaModalidade> TbMedalhaModalidades { get; set; }

    public virtual DbSet<TbMedalhaNivel> TbMedalhaNivels { get; set; }

    public virtual DbSet<TbModalidade> TbModalidades { get; set; }

    public virtual DbSet<TbTreinador> TbTreinadors { get; set; }

    public virtual DbSet<TbTreinadorRedeSocial> TbTreinadorRedeSocials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\;Initial Catalog=SouMaisFit;Integrated Security=true;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<TbAluno>(entity =>
        {
            entity.HasKey(e => e.AluCodigo);

            entity.ToTable("TbAluno");

            entity.Property(e => e.AluDataNasc).HasColumnType("date");
            entity.Property(e => e.AluEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AluFone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.AluId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AluID");
            entity.Property(e => e.AluImagem)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.AluNome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AluObs).HasColumnType("text");
            entity.Property(e => e.AluOneSignalId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AluOneSignalID");
            entity.Property(e => e.AluSenha)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AluSexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.AluStravaCode)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.TreCodigoNavigation).WithMany(p => p.TbAlunos)
                .HasForeignKey(d => d.TreCodigo)
                .HasConstraintName("FK_TbAluno_TbTreinador");
        });

        modelBuilder.Entity<TbAlunoAtividade>(entity =>
        {
            entity.HasKey(e => e.AluAtiCodigo);

            entity.ToTable("TbAlunoAtividade");

            entity.Property(e => e.AluAtiCadencia).HasComment("Pode ser usada tanto para corrida, caminhada e natação para cadência de braçada");
            entity.Property(e => e.AluAtiCidade)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AluAtiDataHora).HasColumnType("datetime");
            entity.Property(e => e.AluAtiDescricao)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AluAtiElevacao).HasComment("Ganho de Elevação");
            entity.Property(e => e.AluAtiEstado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AluAtiFc)
                .HasComment("Frequencia Cardíaca")
                .HasColumnName("AluAtiFC");
            entity.Property(e => e.AluAtiId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AluAtiID");
            entity.Property(e => e.AluAtiObs).HasColumnType("text");
            entity.Property(e => e.AluAtiPotencia).HasComment("Medida usada na atividade de pedalada");
            entity.Property(e => e.AluAtiStrava).HasComment("Código da Atividade no Strava");
            entity.Property(e => e.AluAtiTipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("M (Manual) ou S (Sincronizada)");

            entity.HasOne(d => d.AluCodigoNavigation).WithMany(p => p.TbAlunoAtividades)
                .HasForeignKey(d => d.AluCodigo)
                .HasConstraintName("FK_TbAlunoAtividade_TbAluno");

            entity.HasOne(d => d.ModCodigoNavigation).WithMany(p => p.TbAlunoAtividades)
                .HasForeignKey(d => d.ModCodigo)
                .HasConstraintName("FK_TbAlunoAtividade_TbModalidade");
        });

        modelBuilder.Entity<TbAlunoAtividadeImagem>(entity =>
        {
            entity.HasKey(e => e.AluAtiImgCodigo);

            entity.ToTable("TbAlunoAtividadeImagem");

            entity.Property(e => e.AluAtiImgDescricao).HasColumnType("text");
            entity.Property(e => e.AluAtiImgImagem)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.AluAtiCodigoNavigation).WithMany(p => p.TbAlunoAtividadeImagems)
                .HasForeignKey(d => d.AluAtiCodigo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TbAlunoAtividadeImagem_TbAlunoAtividadeImagem");
        });

        modelBuilder.Entity<TbAlunoDesafio>(entity =>
        {
            entity.HasKey(e => e.AluDesCodigo);

            entity.ToTable("TbAlunoDesafio");

            entity.HasIndex(e => new { e.AluCodigo, e.DesCodigo }, "IX_TbAlunoDesafio").IsUnique();

            entity.HasOne(d => d.AluCodigoNavigation).WithMany(p => p.TbAlunoDesafios)
                .HasForeignKey(d => d.AluCodigo)
                .HasConstraintName("FK_TbAlunoDesafio_TbAluno");

            entity.HasOne(d => d.DesCodigoNavigation).WithMany(p => p.TbAlunoDesafios)
                .HasForeignKey(d => d.DesCodigo)
                .HasConstraintName("FK_TbAlunoDesafio_TbDesafio");
        });

        modelBuilder.Entity<TbAlunoEvento>(entity =>
        {
            entity.HasKey(e => e.AluEveCodigo);

            entity.ToTable("TbAlunoEvento");

            entity.HasIndex(e => new { e.AluCodigo, e.EveCodigo }, "IX_TbAlunoEvento").IsUnique();

            entity.HasOne(d => d.AluCodigoNavigation).WithMany(p => p.TbAlunoEventos)
                .HasForeignKey(d => d.AluCodigo)
                .HasConstraintName("FK_TbAlunoEvento_TbAluno");

            entity.HasOne(d => d.EveCodigoNavigation).WithMany(p => p.TbAlunoEventos)
                .HasForeignKey(d => d.EveCodigo)
                .HasConstraintName("FK_TbAlunoEvento_TbEvento");
        });

        modelBuilder.Entity<TbDesafio>(entity =>
        {
            entity.HasKey(e => e.DesCodigo);

            entity.ToTable("TbDesafio");

            entity.Property(e => e.DesDataFim).HasColumnType("datetime");
            entity.Property(e => e.DesDataInicio).HasColumnType("datetime");
            entity.Property(e => e.DesDataInicioExibicao).HasColumnType("datetime");
            entity.Property(e => e.DesDescricao).HasColumnType("text");
            entity.Property(e => e.DesId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DesID");
            entity.Property(e => e.DesImagem)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DesNome)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.TreCodigoNavigation).WithMany(p => p.TbDesafios)
                .HasForeignKey(d => d.TreCodigo)
                .HasConstraintName("FK_TbDesafio_TbTreinador");
        });

        modelBuilder.Entity<TbDesafioModalidade>(entity =>
        {
            entity.HasKey(e => e.DesModCodigo);

            entity.ToTable("TbDesafioModalidade");

            entity.HasOne(d => d.DesCodigoNavigation).WithMany(p => p.TbDesafioModalidades)
                .HasForeignKey(d => d.DesCodigo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TbDesafioModalidade_TbDesafio");

            entity.HasOne(d => d.ModCodigoNavigation).WithMany(p => p.TbDesafioModalidades)
                .HasForeignKey(d => d.ModCodigo)
                .HasConstraintName("FK_TbDesafioModalidade_TbModalidade");
        });

        modelBuilder.Entity<TbEvento>(entity =>
        {
            entity.HasKey(e => e.EveCodigo);

            entity.ToTable("TbEvento");

            entity.Property(e => e.EveDataFim).HasColumnType("datetime");
            entity.Property(e => e.EveDataInicio).HasColumnType("datetime");
            entity.Property(e => e.EveDataInicioExibicao).HasColumnType("datetime");
            entity.Property(e => e.EveDescricao).HasColumnType("text");
            entity.Property(e => e.EveId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EveID");
            entity.Property(e => e.EveImagem)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EveNome)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.TreCodigoNavigation).WithMany(p => p.TbEventos)
                .HasForeignKey(d => d.TreCodigo)
                .HasConstraintName("FK_TbEvento_TbEvento");
        });

        modelBuilder.Entity<TbMedalha>(entity =>
        {
            entity.HasKey(e => e.MedCodigo);

            entity.ToTable("TbMedalha");

            entity.Property(e => e.MedNome)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbMedalhaModalidade>(entity =>
        {
            entity.HasKey(e => e.MedModCodigo);

            entity.ToTable("TbMedalhaModalidade");

            entity.HasOne(d => d.MedCodigoNavigation).WithMany(p => p.TbMedalhaModalidades)
                .HasForeignKey(d => d.MedCodigo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_TbMedalhaModalidade_TbMedalha");

            entity.HasOne(d => d.ModCodigoNavigation).WithMany(p => p.TbMedalhaModalidades)
                .HasForeignKey(d => d.ModCodigo)
                .HasConstraintName("FK_TbMedalhaModalidade_TbModalidade");
        });

        modelBuilder.Entity<TbMedalhaNivel>(entity =>
        {
            entity.HasKey(e => e.MedNivCodigo);

            entity.ToTable("TbMedalhaNivel");

            entity.Property(e => e.MedNivId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MedNivID");
            entity.Property(e => e.MedNivImagem)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.MedCodigoNavigation).WithMany(p => p.TbMedalhaNivels)
                .HasForeignKey(d => d.MedCodigo)
                .HasConstraintName("FK_TbMedalhaNivel_TbMedalha");
        });

        modelBuilder.Entity<TbModalidade>(entity =>
        {
            entity.HasKey(e => e.ModCodigo);

            entity.ToTable("TbModalidade");

            entity.Property(e => e.ModId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ModID");
            entity.Property(e => e.ModImagem)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ModNome)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbTreinador>(entity =>
        {
            entity.HasKey(e => e.TreCodigo);

            entity.ToTable("TbTreinador");

            entity.Property(e => e.TreBio).HasColumnType("text");
            entity.Property(e => e.TreEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TreFone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TreId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TreID");
            entity.Property(e => e.TreImagem)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.TreNome)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TreOneSignalId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TreOneSignalID");
            entity.Property(e => e.TreSenha)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbTreinadorRedeSocial>(entity =>
        {
            entity.HasKey(e => e.TreRedCodigo);

            entity.ToTable("TbTreinadorRedeSocial");

            entity.Property(e => e.TreRedLink)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.TreCodigoNavigation).WithMany(p => p.TbTreinadorRedeSocials)
                .HasForeignKey(d => d.TreCodigo)
                .HasConstraintName("FK_TbTreinadorRedeSocial_TbTreinador");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
