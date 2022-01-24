using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Infrastructure;
using System;
using ERP.Domain.AggregatesModel.EmployeeAggregate;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ERP.Infrastructure.EntityConfigurations
{
    class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entityConfiguration)
        {
            entityConfiguration.ToTable("Employees", ERPContext.DEFAULT_SCHEMA);

            entityConfiguration.HasKey(e => e.Id).HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);


            entityConfiguration.Property<string>("FirstName").IsRequired(true);
            entityConfiguration.Property<string>("MiddleName").IsRequired(true);
            entityConfiguration.Property<string>("LastName").IsRequired(false);
            entityConfiguration.Property<DateTime?>("DateOfBirth").IsRequired(false);
            entityConfiguration.Property<bool>("IsEnabled").IsRequired(true);
            entityConfiguration.Property<DateTime>("CreatedOn").IsRequired(true);
            entityConfiguration.Property<DateTime?>("DeletedOn").IsRequired(false);


            entityConfiguration.HasOne(e => e.Nationality)
                .WithMany()
                .HasForeignKey("NationalityId");

            entityConfiguration.HasOne(e => e.Gender)
                .WithMany()
                .HasForeignKey("GenderId");
        }
    }
}
