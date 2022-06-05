using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctor");
            builder.HasKey(e => e.IdDoctor);

            builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(100).IsRequired();

            builder.HasData(
                new Doctor
                {
                    IdDoctor = 1,
                    FirstName = "Marcin",
                    LastName = "Kulik",
                    Email = "marcin@kul.com"
                }, 
                new Doctor
                {
                    IdDoctor = 2,
                    FirstName = "Michał",
                    LastName = "Źrebak",
                    Email = "m@zrebak.pl"
                },
                new Doctor
                {
                    IdDoctor = 3,
                    FirstName = "Kacper",
                    LastName = "Kowalski",
                    Email = "k@kow.kk"
                }
            );
        }
    }
}
