using CE.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CE.EFC.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(d => d.Id).HasName("C_ID");

            builder.ToTable("COMPANY");

            builder.Property(d => d.Id).HasColumnName("C_ID").IsRequired();
            builder.Property(d => d.Name).HasColumnName("C_NAME").IsRequired();
            builder.Property(d => d.Description).HasColumnName("C_DESCRIPTION");
        }
    }
}