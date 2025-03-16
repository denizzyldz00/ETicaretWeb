using System;
using System.Collections.Generic;
using ETicaretWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace ETicaretWeb.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DimKategoriler> DimKategorilers { get; set; }

    public virtual DbSet<DimMusteriler> DimMusterilers { get; set; }

    public virtual DbSet<DimTarih> DimTarihs { get; set; }

    public virtual DbSet<DimUrunler> DimUrunlers { get; set; }

    public virtual DbSet<FactSatislar> FactSatislars { get; set; }

    public virtual DbSet<Kategoriler> Kategorilers { get; set; }

    public virtual DbSet<Musteriler> Musterilers { get; set; }

    public virtual DbSet<SiparisDetaylari> SiparisDetaylaris { get; set; }

    public virtual DbSet<Siparisler> Siparislers { get; set; }

    public virtual DbSet<Tedarikciler> Tedarikcilers { get; set; }

    public virtual DbSet<Urunler> Urunlers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DENIZ_YILDIZ\\DEVELOPEREDITION;Database=ETicaretDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DimKategoriler>(entity =>
        {
            entity.HasKey(e => e.KategoriKey).HasName("PK__DimKateg__19A72914A5CE92A1");

            entity.ToTable("DimKategoriler");

            entity.Property(e => e.Aciklama).HasMaxLength(500);
            entity.Property(e => e.BaslangicTarihi).HasColumnType("datetime");
            entity.Property(e => e.BitisTarihi).HasColumnType("datetime");
            entity.Property(e => e.KategoriAdi).HasMaxLength(50);
            entity.Property(e => e.KategoriId).HasColumnName("KategoriID");
        });

        modelBuilder.Entity<DimMusteriler>(entity =>
        {
            entity.HasKey(e => e.MusteriKey).HasName("PK__DimMuste__0EEBCBBFDBF681CF");

            entity.ToTable("DimMusteriler");

            entity.Property(e => e.Ad).HasMaxLength(50);
            entity.Property(e => e.BaslangicTarihi).HasColumnType("datetime");
            entity.Property(e => e.BitisTarihi).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.MusteriId).HasColumnName("MusteriID");
            entity.Property(e => e.Sehir).HasMaxLength(50);
            entity.Property(e => e.Soyad).HasMaxLength(50);
            entity.Property(e => e.TamAd).HasMaxLength(100);
            entity.Property(e => e.Ulke).HasMaxLength(50);
        });

        modelBuilder.Entity<DimTarih>(entity =>
        {
            entity.HasKey(e => e.TarihKey).HasName("PK__DimTarih__7617C871D3EC16EB");

            entity.ToTable("DimTarih");

            entity.Property(e => e.TarihKey).ValueGeneratedNever();
            entity.Property(e => e.AyAdi).HasMaxLength(30);
            entity.Property(e => e.GunAdi).HasMaxLength(30);
        });

        modelBuilder.Entity<DimUrunler>(entity =>
        {
            entity.HasKey(e => e.UrunKey).HasName("PK__DimUrunl__2B5C1364479B92F8");

            entity.ToTable("DimUrunler");

            entity.Property(e => e.BaslangicTarihi).HasColumnType("datetime");
            entity.Property(e => e.BirimFiyat).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.BitisTarihi).HasColumnType("datetime");
            entity.Property(e => e.KategoriAdi).HasMaxLength(50);
            entity.Property(e => e.TedarikciAdi).HasMaxLength(100);
            entity.Property(e => e.UrunAdi).HasMaxLength(100);
            entity.Property(e => e.UrunId).HasColumnName("UrunID");
        });

        modelBuilder.Entity<FactSatislar>(entity =>
        {
            entity.HasKey(e => e.SatisKey).HasName("PK__FactSati__1448664478AD7440");

            entity.ToTable("FactSatislar");

            entity.Property(e => e.BirimFiyat).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.IndirimTutari).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NetTutar).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SiparisDetayId).HasColumnName("SiparisDetayID");
            entity.Property(e => e.SiparisId).HasColumnName("SiparisID");
            entity.Property(e => e.ToplamTutar).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.KategoriKeyNavigation).WithMany(p => p.FactSatislars)
                .HasForeignKey(d => d.KategoriKey)
                .HasConstraintName("FK__FactSatis__Kateg__5812160E");

            entity.HasOne(d => d.MusteriKeyNavigation).WithMany(p => p.FactSatislars)
                .HasForeignKey(d => d.MusteriKey)
                .HasConstraintName("FK__FactSatis__Muste__5535A963");

            entity.HasOne(d => d.TarihKeyNavigation).WithMany(p => p.FactSatislars)
                .HasForeignKey(d => d.TarihKey)
                .HasConstraintName("FK__FactSatis__Tarih__571DF1D5");

            entity.HasOne(d => d.UrunKeyNavigation).WithMany(p => p.FactSatislars)
                .HasForeignKey(d => d.UrunKey)
                .HasConstraintName("FK__FactSatis__UrunK__5629CD9C");
        });

        modelBuilder.Entity<Kategoriler>(entity =>
        {
            entity.HasKey(e => e.KategoriId).HasName("PK__Kategori__1782CC92169D4E05");

            entity.ToTable("Kategoriler");

            entity.Property(e => e.KategoriId).HasColumnName("KategoriID");
            entity.Property(e => e.Aciklama).HasMaxLength(500);
            entity.Property(e => e.KategoriAdi).HasMaxLength(50);
        });

        modelBuilder.Entity<Musteriler>(entity =>
        {
            entity.HasKey(e => e.MusteriId).HasName("PK__Musteril__726244711D699FF2");

            entity.ToTable("Musteriler");

            entity.HasIndex(e => e.Email, "IX_Musteriler_Email");

            entity.HasIndex(e => e.Email, "UQ__Musteril__A9D10534442A583D").IsUnique();

            entity.Property(e => e.MusteriId).HasColumnName("MusteriID");
            entity.Property(e => e.Ad).HasMaxLength(50);
            entity.Property(e => e.Adres).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.KayitTarihi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Soyad).HasMaxLength(50);
            entity.Property(e => e.Telefon).HasMaxLength(15);
        });

        modelBuilder.Entity<SiparisDetaylari>(entity =>
        {
            entity.HasKey(e => e.SiparisDetayId).HasName("PK__SiparisD__DA4BD832E913B257");

            entity.ToTable("SiparisDetaylari");

            entity.HasIndex(e => e.SiparisId, "IX_SiparisDetaylari_SiparisID");

            entity.Property(e => e.SiparisDetayId).HasColumnName("SiparisDetayID");
            entity.Property(e => e.BirimFiyat).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Indirim)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(5, 2)");
            entity.Property(e => e.SiparisId).HasColumnName("SiparisID");
            entity.Property(e => e.UrunId).HasColumnName("UrunID");

            entity.HasOne(d => d.Siparis).WithMany(p => p.SiparisDetaylaris)
                .HasForeignKey(d => d.SiparisId)
                .HasConstraintName("FK__SiparisDe__Sipar__48CFD27E");

            entity.HasOne(d => d.Urun).WithMany(p => p.SiparisDetaylaris)
                .HasForeignKey(d => d.UrunId)
                .HasConstraintName("FK__SiparisDe__UrunI__49C3F6B7");
        });

        modelBuilder.Entity<Siparisler>(entity =>
        {
            entity.HasKey(e => e.SiparisId).HasName("PK__Siparisl__C3F03BDDD52837F3");

            entity.ToTable("Siparisler");

            entity.HasIndex(e => e.MusteriId, "IX_Siparisler_MusteriID");

            entity.HasIndex(e => e.SiparisTarihi, "IX_Siparisler_SiparisTarihi");

            entity.Property(e => e.SiparisId).HasColumnName("SiparisID");
            entity.Property(e => e.MusteriId).HasColumnName("MusteriID");
            entity.Property(e => e.SiparisDurumu).HasMaxLength(20);
            entity.Property(e => e.SiparisTarihi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TeslimTarihi).HasColumnType("datetime");
            entity.Property(e => e.TeslimatAdresi).HasMaxLength(500);
            entity.Property(e => e.ToplamTutar).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Musteri).WithMany(p => p.Siparislers)
                .HasForeignKey(d => d.MusteriId)
                .HasConstraintName("FK__Siparisle__Muste__44FF419A");
        });

        modelBuilder.Entity<Tedarikciler>(entity =>
        {
            entity.HasKey(e => e.TedarikciId).HasName("PK__Tedarikc__E0B82CC145BAE682");

            entity.ToTable("Tedarikciler");

            entity.Property(e => e.TedarikciId).HasColumnName("TedarikciID");
            entity.Property(e => e.Adres).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirmaAdi).HasMaxLength(100);
            entity.Property(e => e.Telefon).HasMaxLength(15);
            entity.Property(e => e.VergiNo).HasMaxLength(20);
            entity.Property(e => e.YetkiliAdi).HasMaxLength(50);
        });

        modelBuilder.Entity<Urunler>(entity =>
        {
            entity.HasKey(e => e.UrunId).HasName("PK__Urunler__623D364B16B56A19");

            entity.ToTable("Urunler");

            entity.HasIndex(e => e.KategoriId, "IX_Urunler_KategoriID");

            entity.HasIndex(e => e.UrunAdi, "IX_Urunler_UrunAdi");

            entity.Property(e => e.UrunId).HasColumnName("UrunID");
            entity.Property(e => e.BirimFiyat).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EklenmeTarihi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.KategoriId).HasColumnName("KategoriID");
            entity.Property(e => e.TedarikciId).HasColumnName("TedarikciID");
            entity.Property(e => e.UrunAdi).HasMaxLength(100);

            entity.HasOne(d => d.Kategori).WithMany(p => p.Urunlers)
                .HasForeignKey(d => d.KategoriId)
                .HasConstraintName("FK__Urunler__Kategor__3F466844");

            entity.HasOne(d => d.Tedarikci).WithMany(p => p.Urunlers)
                .HasForeignKey(d => d.TedarikciId)
                .HasConstraintName("FK__Urunler__Tedarik__403A8C7D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
