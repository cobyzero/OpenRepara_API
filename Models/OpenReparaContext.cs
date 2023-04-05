using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OpenRepara_API.Models;

public partial class OpenReparaContext : DbContext
{
    public OpenReparaContext()
    {
    }

    public OpenReparaContext(DbContextOptions<OpenReparaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<User> Users { get; set; }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Clientes");

            entity.ToTable("Client");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Number)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("number");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Inventario");

            entity.ToTable("Inventory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Imei)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("imei");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("model");
            entity.Property(e => e.TypeService)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("typeService");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Ordenes");

            entity.ToTable("Order");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.DateOrder)
                .HasColumnType("datetime")
                .HasColumnName("dateOrder");
            entity.Property(e => e.Dispositive)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("dispositive");
            entity.Property(e => e.EmailClient)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("emailClient");
            entity.Property(e => e.FailDispositive)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("failDispositive");
            entity.Property(e => e.ImeiDispositive)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("imeiDispositive");
            entity.Property(e => e.MarcaDispositive)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marcaDispositive");
            entity.Property(e => e.ModelDispositive)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modelDispositive");
            entity.Property(e => e.NameClient)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nameClient");
            entity.Property(e => e.NumberClient)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("numberClient");
            entity.Property(e => e.Observation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("observation");
            entity.Property(e => e.PassDispositive)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("passDispositive");
            entity.Property(e => e.PinDispositive)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pinDispositive");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TypeService)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("typeService");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Ventas");

            entity.ToTable("Sale");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("clientName");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.DateService)
                .HasColumnType("datetime")
                .HasColumnName("dateService");
            entity.Property(e => e.PriceService).HasColumnName("priceService");
            entity.Property(e => e.TypeService)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("typeService");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Users");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Authority).HasColumnName("authority");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
