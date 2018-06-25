using INMETRO.REGOIAS.WEB.Models;
using Microsoft.EntityFrameworkCore;

namespace INMETRO.REGOIAS.WEB.DADOS
{
    public class OrgContexto : DbContext
    {
        public OrgContexto(DbContextOptions<OrgContexto> options) : base(options)
        {
            
        }

        public DbSet<Organismo> Organismos { get; set; }
        public DbSet<IntegracaoOrganismo> Integracao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new OrganismoMap());
            modelBuilder.Entity<Organismo>().ToTable("TB_ORGANISMO");
            modelBuilder.Entity<IntegracaoOrganismo>().ToTable("TB_INTEGRACAO_INFO");

            //Configura OrganismoId como PK para FTPInfo
            modelBuilder.Entity<IntegracaoOrganismo>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Organismo>()
                .HasOne(s => s.IntegracaoInfo) // Mark Address property optional in Student entity
                .WithMany()
                .HasForeignKey(ad => ad.Id);
        }
    }
}