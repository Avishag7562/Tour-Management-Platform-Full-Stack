using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class TravelContext : DbContext
{
    public TravelContext()
    {
    }

    public TravelContext(DbContextOptions<TravelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OrederPlace> OrederPlaces { get; set; }

    public virtual DbSet<TravelType> TravelTypes { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server= AVISHAG;Database=travel;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrederPlace>(entity =>
        {
            entity.HasKey(e => e.CodeOrder).HasName("PK__OrederPl__0C6E97C62432072C");

            entity.Property(e => e.CodeOrder).HasColumnName("codeOrder");
            entity.Property(e => e.CodeTrip).HasColumnName("codeTrip");
            entity.Property(e => e.CodeUser).HasColumnName("codeUser");
            entity.Property(e => e.DateOrder)
                .HasColumnType("date")
                .HasColumnName("dateOrder");
            entity.Property(e => e.NumPlaces).HasColumnName("numPlaces");
            entity.Property(e => e.OrderHour).HasColumnName("orderHour");

            entity.HasOne(d => d.CodeTripNavigation).WithMany(p => p.OrederPlaces)
                .HasForeignKey(d => d.CodeTrip)
                .HasConstraintName("FK__OrederPla__codeT__5165187F");

            entity.HasOne(d => d.CodeUserNavigation).WithMany(p => p.OrederPlaces)
                .HasForeignKey(d => d.CodeUser)
                .HasConstraintName("FK__OrederPla__codeU__5070F446");
        });

        modelBuilder.Entity<TravelType>(entity =>
        {
            entity.HasKey(e => e.CodeType).HasName("PK__TravelTy__9ACFEED2A0695E4D");

            entity.ToTable("TravelType");

            entity.Property(e => e.CodeType).HasColumnName("codeType");
            entity.Property(e => e.NameType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nameType");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.CodeTrip).HasName("PK__Trips__9EAEE5847B00C6A0");

            entity.Property(e => e.CodeTrip).HasColumnName("codeTrip");
            entity.Property(e => e.AvailablePlaces).HasColumnName("availablePlaces");
            entity.Property(e => e.CodeType).HasColumnName("codeType");
            entity.Property(e => e.DateTrip)
                .HasColumnType("date")
                .HasColumnName("dateTrip");
            entity.Property(e => e.Destination)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("destination");
            entity.Property(e => e.Img)
                .HasColumnType("text")
                .HasColumnName("img");
            entity.Property(e => e.LeavingTime).HasColumnName("leavingTime");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.TripHours).HasColumnName("tripHours");

            entity.HasOne(d => d.CodeTypeNavigation).WithMany(p => p.Trips)
                .HasForeignKey(d => d.CodeType)
                .HasConstraintName("FK__Trips__codeType__4D94879B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.CodeUser).HasName("PK__Users__66CA1DB565853EC9");

            entity.Property(e => e.CodeUser).HasColumnName("codeUser");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EntryPassword)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("entryPassword");
            entity.Property(e => e.FirstAid).HasColumnName("firstAid");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
