using Domain.Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Application.DataAccess.Mapping
{
    public class ExampleModelConfiguration : IEntityTypeConfiguration<ExampleModel>
    {
        public void Configure(EntityTypeBuilder<ExampleModel> builder)
        {
            builder.ToTable("ExampleModel");
            builder.HasKey("Id");
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name);
        }
    }
}