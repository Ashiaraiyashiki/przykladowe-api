using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configurations
{
    public class PrescriptionConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.ToTable("Prescription");
            builder.HasKey(e => e.IdPrescription);

            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.DueDate).IsRequired();

            builder.HasOne(e => e.Doctor).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdDoctor).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasOne(e => e.Patient).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdPatient).OnDelete(DeleteBehavior.ClientCascade);

            builder.HasData(
                new Prescription
                {
                    IdPrescription = 1,
                    IdPatient = 1,
                    IdDoctor = 1,
                    Date = new System.DateTime(2022, 1, 1),
                    DueDate = new System.DateTime(2022, 5, 1)
                }
            );
        }
    }
}
