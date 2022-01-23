using CE.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CE.EFC.Configuration
{
    public class CompanyEmployeeConfiguration : IEntityTypeConfiguration<CompanyEmployee>
    {
        public void Configure(EntityTypeBuilder<CompanyEmployee> builder)
        {
            builder.HasKey(d => new { d.CompanyId, d.EmployeeId });

            builder.ToTable("COMPANY_EMPLOYEE");

            builder.HasOne(d => d.Company)
                   .WithMany(dd => dd.CompanyEmployees)
                   .HasForeignKey(d => d.CompanyId);

            builder.HasOne(d => d.Employee)
                   .WithMany(dd => dd.CompanyEmployees)
                   .HasForeignKey(d => d.EmployeeId);

            builder.Property(d => d.CompanyId).HasColumnName("CE_COMPANY_ID").IsRequired();
            builder.Property(d => d.EmployeeId).HasColumnName("CE_EMPLOYEE_ID").IsRequired();
        }
    }
}