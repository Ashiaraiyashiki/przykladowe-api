using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configurations
{
    public class PrescriptionMedicamentConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            builder.ToTable("Prescription_Medicament");
            builder.HasKey(e => new { e.IdPrescription, e.IdMedicament });

            builder.Property(e => e.Dose).IsRequired();
            builder.Property(e => e.Details).HasMaxLength(100).IsRequired();

            builder.HasOne(e => e.Medicament).WithMany(e => e.PrescriptionMedicaments).HasForeignKey(e => e.IdMedicament).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasOne(e => e.Prescription).WithMany(e => e.PrescriptionMedicaments).HasForeignKey(e => e.IdPrescription).OnDelete(DeleteBehavior.ClientCascade);

            builder.HasData(
                new PrescriptionMedicament
                {
                    IdPrescription = 1,
                    IdMedicament = 1,
                    Dose = 1,
                    Details = ""
                },
                new PrescriptionMedicament
                {
                    IdPrescription = 1,
                    IdMedicament = 2,
                    Dose = 3,
                    Details = ""
                }
            );
        }
    }
}
