using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FirstWepApp.Models;

public partial class GasServicesContext : DbContext
{
    public GasServicesContext()
    {
    }

    public GasServicesContext(DbContextOptions<GasServicesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientService> ClientServices { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Clients__75A5D8F8BC03456D");

            entity.Property(e => e.ClientId).HasColumnName("Client_Id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
        });

        modelBuilder.Entity<ClientService>(entity =>
        {
            entity.HasKey(e => new { e.ClientId, e.ServiceId }).HasName("PK__Client_S__AE747AC3BA2443DE");

            entity.ToTable("Client_Services");

            entity.Property(e => e.ClientId).HasColumnName("Client_Id");
            entity.Property(e => e.ServiceId).HasColumnName("Service_Id");
            entity.Property(e => e.DateHiring).HasColumnName("Date_Hiring");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientServices)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Client_Se__Clien__3B75D760");

            entity.HasOne(d => d.Service).WithMany(p => p.ClientServices)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Client_Se__Servi__3C69FB99");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Services__BD1A23BC7A3718C1");

            entity.Property(e => e.ServiceId).HasColumnName("Service_Id");
            entity.Property(e => e.DescriptionService)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Description_Service");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
