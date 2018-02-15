using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplFilterInput.Model
{
    public class Car
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("car");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .UseSqlServerIdentityColumn();

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(50);
        }

        public static CarConfiguration Create()
        {
            return new CarConfiguration();
        }
    }
}
