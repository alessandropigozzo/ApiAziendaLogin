using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiAziendaLogin.Models;

public partial class LoginDbContext : DbContext
{
    public LoginDbContext()
    {
    }

    public LoginDbContext(DbContextOptions<LoginDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Anagrafiche> Anagrafiche { get; set; }

    public virtual DbSet<Immagini> Immagini { get; set; }

    public virtual DbSet<Ruoli> Ruoli { get; set; }

    public virtual DbSet<Utenti> Utenti { get; set; }

    public virtual DbSet<UtentiRuoli> UtentiRuoli { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-V6IELDF;Database=LoginDb;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anagrafiche>(entity =>
        {
            entity.HasKey(e => e.IdAnagrafica);

            entity.ToTable("Anagrafiche");
        });

        modelBuilder.Entity<Immagini>(entity =>
        {
            entity.HasKey(e => e.IdImmagine);

            entity.ToTable("Immagini");
        });

        modelBuilder.Entity<Ruoli>(entity =>
        {
            entity.HasKey(e => e.IdRuolo);

            entity.ToTable("Ruoli");

            entity.Property(e => e.IdRuolo).ValueGeneratedNever();
        });

        modelBuilder.Entity<Utenti>(entity =>
        {
            entity.HasKey(e => e.IdUtente);

            entity.ToTable("Utenti");

            entity.HasIndex(e => e.IdAnagrafica, "IX_Utenti_IdAnagrafica").IsUnique();

            entity.HasIndex(e => e.IdImmagine, "IX_Utenti_IdImmagine").IsUnique();

            entity.HasOne(d => d.IdAnagraficaNavigation).WithOne(p => p.Utenti).HasForeignKey<Utenti>(d => d.IdAnagrafica);

            entity.HasOne(d => d.IdImmagineNavigation).WithOne(p => p.Utenti).HasForeignKey<Utenti>(d => d.IdImmagine);
        });

        modelBuilder.Entity<UtentiRuoli>(entity =>
        {
            entity.HasKey(e => e.IdUtenteRuolo);

            entity.ToTable("UtentiRuoli");

            entity.HasIndex(e => e.IdRuolo, "IX_UtentiRuoli_IdRuolo");

            entity.HasIndex(e => e.IdUtente, "IX_UtentiRuoli_IdUtente");

            entity.HasOne(d => d.IdRuoloNavigation).WithMany(p => p.UtentiRuolis).HasForeignKey(d => d.IdRuolo);

            entity.HasOne(d => d.IdUtenteNavigation).WithMany(p => p.UtentiRuolis).HasForeignKey(d => d.IdUtente);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
