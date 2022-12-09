using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mobilebook.Mvvm.Model;

public partial class MobilebookdbContext : DbContext
{
    public MobilebookdbContext()
    {
    }

    public MobilebookdbContext(DbContextOptions<MobilebookdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Call> Calls { get; set; }

    public virtual DbSet<CallUser> CallUsers { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=REALNOZVER\\SQLEXPRESS;Initial Catalog=Mobilebookdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Call>(entity =>
        {
            entity.HasKey(e => e.IdCall).HasName("PK__Call__C71E343BC9401420");

            entity.ToTable("Call");

            entity.Property(e => e.IdCall).HasColumnName("id_call");
            entity.Property(e => e.Date)
                .HasMaxLength(20)
                .HasColumnName("date");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.IdPrice).HasColumnName("id_price");
            entity.Property(e => e.PhoneAbonent)
                .HasMaxLength(10)
                .HasColumnName("phone_abonent");

            entity.HasOne(d => d.IdPriceNavigation).WithMany(p => p.Calls)
                .HasForeignKey(d => d.IdPrice)
                .HasConstraintName("FK__Call__id_price__286302EC");
        });

        modelBuilder.Entity<CallUser>(entity =>
        {
            entity.HasKey(e => e.IdCallUser).HasName("PK__Call_Use__9C34F8765CCA0A86");

            entity.ToTable("Call_User");

            entity.Property(e => e.IdCallUser).HasColumnName("id_call_user");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.IdCall).HasColumnName("id_call");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.OutInt)
                .HasMaxLength(20)
                .HasColumnName("out_int");

            entity.HasOne(d => d.IdCallNavigation).WithMany(p => p.CallUsers)
                .HasForeignKey(d => d.IdCall)
                .HasConstraintName("FK__Call_User__id_ca__2B3F6F97");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.CallUsers)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Call_User__id_us__2C3393D0");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasKey(e => e.IdPrice).HasName("PK__Price__D8A23E830CC0CED5");

            entity.ToTable("Price");

            entity.Property(e => e.IdPrice).HasColumnName("id_price");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Tariff).HasColumnName("tariff");
            entity.Property(e => e.TimeOfDay)
                .HasMaxLength(20)
                .HasColumnName("time_of_day");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__User__D2D14637D5C16420");

            entity.ToTable("User");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Login).HasMaxLength(30);
            entity.Property(e => e.Name).HasMaxLength(30);
            entity.Property(e => e.NaturalLegacyEntity)
                .HasMaxLength(30)
                .HasColumnName("natural_legacy_entity");
            entity.Property(e => e.Password).HasMaxLength(30);
            entity.Property(e => e.Patronymic).HasMaxLength(30);
            entity.Property(e => e.Phone).HasMaxLength(10);
            entity.Property(e => e.Surname).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
