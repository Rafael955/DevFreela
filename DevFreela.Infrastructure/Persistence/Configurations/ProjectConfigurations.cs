using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectConfigurations : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.Freelancer)
                .WithMany(f => f.FreelanceProjects)
                .HasForeignKey(p => p.FreelancerId)
                .OnDelete(DeleteBehavior.Restrict); // Impede deleção de entidades que tenham relacionamento com outras.

            builder.HasOne(p => p.Client)
                .WithMany(c => c.OwnedProjects)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.TotalCost)
                .HasColumnType("decimal(18,2)");
        }
    }
}
