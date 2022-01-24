using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Infrastructure;
using System;
using ERP.Domain.AggregatesModel.DepartmentAggregate;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ERP.Infrastructure.EntityConfigurations
{
    class DepartmentEntityTypeConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> entityConfiguration)
        {
            entityConfiguration.ToTable("Departments", ERPContext.DEFAULT_SCHEMA);

            entityConfiguration.HasKey(e => e.Id).HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            entityConfiguration.Property<string>("Name").IsRequired(true);
            entityConfiguration.Property<int?>("ParentId").IsRequired(false);
            entityConfiguration.Property<bool>("IsActive").IsRequired(true);
            entityConfiguration.Property<bool>("IsEnabled").IsRequired(true);
            entityConfiguration.Property<DateTime>("CreatedOn").IsRequired(true);
            entityConfiguration.Property<DateTime?>("DeletedOn").IsRequired(false);


            entityConfiguration.HasOne(e => e.Parent)
                .WithMany()
                .HasForeignKey("ParentId");
        }
    }
}
