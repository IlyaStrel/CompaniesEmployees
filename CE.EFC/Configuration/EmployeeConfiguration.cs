using CE.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CE.EFC.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(d => d.Id).HasName("E_ID");

            builder.ToTable("EMPLOYEE");

            builder.Property(d => d.Id).HasColumnName("E_ID").IsRequired();
            builder.Property(d => d.Name).HasColumnName("E_NAME").IsRequired();
            builder.Property(d => d.Patronymic).HasColumnName("E_PATRONYMIC");
            builder.Property(d => d.Surname).HasColumnName("E_SURNAME").IsRequired();
            builder.Property(d => d.Address).HasColumnName("E_ADDRESS");
            builder.Property(d => d.Phone).HasColumnName("E_PHONE");
            builder.Property(d => d.Post).HasColumnName("E_POST");
        }
    }
}