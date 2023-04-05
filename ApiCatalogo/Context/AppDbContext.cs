using ApiCatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogo.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Volume>? Volumes { get; set; }
        public DbSet<Order>? Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //order
            mb.Entity<Order>().HasKey(c => c.OrderId);

            //public string? OriginPointCode { get; set; }
            //public string? OriginPartnerPointCode { get; set; }
            //public string? OriginPostalCode { get; set; }
            //public string? ToCollect { get; set; }
            //public string? DestinationPointCode { get; set; }
            //public string? DestinationPostalCode { get; set; }
            //public bool ToDelivery { get; set; }
            //public string? ServiceCode { get; set; }
            //public int InsuranceType { get; set; }
            //public string? InsuranceCompany { get; set; }
            //public string? InsurancePolicyNumber { get; set; }
            //public decimal DeclaredValue { get; set; }
            //public string? PreviousDocuments { get; set; }

            mb.Entity<Order>().Property(c => c.OriginPointCode).HasColumnType("varchar").HasMaxLength(36);
            mb.Entity<Order>().Property(c => c.OriginPartnerPointCode).HasColumnType("varchar").HasMaxLength(36);
            mb.Entity<Order>().Property(c => c.OriginPostalCode).HasColumnType("varchar").HasMaxLength(36);
            mb.Entity<Order>().Property(c => c.ToCollect).HasColumnType("int");
            mb.Entity<Order>().Property(c => c.DestinationPointCode).HasColumnType("varchar").HasMaxLength(36);
            mb.Entity<Order>().Property(c => c.DestinationPostalCode).HasColumnType("varchar").HasMaxLength(36);
            mb.Entity<Order>().Property(c => c.ToDelivery).HasColumnType("int");
            mb.Entity<Order>().Property(c => c.ServiceCode).HasColumnType("varchar").HasMaxLength(36);
            mb.Entity<Order>().Property(c => c.InsuranceType).HasColumnType("int");
            mb.Entity<Order>().Property(c => c.InsuranceCompany).HasColumnType("varchar").HasMaxLength(36);
            mb.Entity<Order>().Property(c => c.InsurancePolicyNumber).HasColumnType("varchar").HasMaxLength(36);
            mb.Entity<Order>().Property(c => c.DeclaredValue).HasColumnType("decimal(7, 7)");
            mb.Entity<Order>().Property(c => c.InsurancePolicyNumber).HasColumnType("varchar").HasMaxLength(36);
            mb.Entity<Order>().Property(c => c.PreviousDocuments).HasColumnType("varchar").HasMaxLength(36);

            //mb.Entity<Order>().Property(c=> c.Nome)
            //                      .HasMaxLength(100)
            //                      .IsRequired();
            //mb.Entity<Order>().Property(c => c.Descricao).HasMaxLength(150).IsRequired();

            //volume
            mb.Entity<Volume>().HasKey(c => c.VolumeId);

            mb.Entity<Volume>().Property(c => c.Pieces).HasColumnType("int");
            mb.Entity<Volume>().Property(c => c.Weight).HasColumnType("decimal(7, 5)");
            mb.Entity<Volume>().Property(c => c.Lenght).HasColumnType("decimal(7, 5)");
            mb.Entity<Volume>().Property(c => c.Width).HasColumnType("decimal(7, 5)");
            mb.Entity<Volume>().Property(c => c.Height).HasColumnType("decimal(7, 5)");

            //relacionamento
            mb.Entity<Volume>()
                .HasOne(c=> c.Order)
                  .WithMany(p=> p.Volumes)
                    .HasForeignKey(c => c.OrderId);
        }
    }
}
