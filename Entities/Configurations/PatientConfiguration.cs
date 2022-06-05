using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("Patient");
            builder.HasKey(e => e.IdPatient);

            builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.Birthdate).IsRequired();

            builder.HasData(
                new Patient
                {
                    IdPatient = 1,
                    FirstName = "Mirosław",
                    LastName = "Księżyk",
                    Birthdate = new System.DateTime(1985, 1, 2)
                },
                new Patient
                {
                    IdPatient = 2,
                    FirstName = "Jakub",
                    LastName = "Zlewek",
                    Birthdate = new System.DateTime(1999, 5, 20)
                }
            );
        }
    }
}
