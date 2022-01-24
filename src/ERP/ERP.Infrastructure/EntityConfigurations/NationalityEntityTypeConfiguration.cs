using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ERP.Infrastructure;
using System;
using ERP.Domain.AggregatesModel.EmployeeAggregate;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ERP.Infrastructure.EntityConfigurations
{
    class NationalityEntityTypeConfiguration : IEntityTypeConfiguration<Nationality>
    {
        public void Configure(EntityTypeBuilder<Nationality> entityConfiguration)
        {
            entityConfiguration.ToTable("Nationalities", ERPContext.DEFAULT_SCHEMA);

            entityConfiguration.HasKey(e => e.Id).HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            entityConfiguration.Property<string>("Name").IsRequired(true);
            entityConfiguration.Property<bool>("IsEnabled").IsRequired(true);
            entityConfiguration.Property<DateTime>("CreatedOn").IsRequired(true);
            entityConfiguration.Property<DateTime?>("DeletedOn").IsRequired(false);
        }
    }
}
