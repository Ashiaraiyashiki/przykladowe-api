using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Repository
{
    public class PrescriptionRepository : RepositoryBase<Prescription>, IPrescriptionRepository
    {
        public PrescriptionRepository(DBContext context) : base(context)
        {
        }

        public Task<Prescription> GetPrescriptionWithDetailsByIdAsync(int id)
        {
            return GetByCondition(e => e.IdPrescription == id)
                .Include(e => e.Doctor)
                .Include(e => e.Patient)
                .Include(e => e.PrescriptionMedicaments)
                .ThenInclude(e => e.Medicament)
                .FirstOrDefaultAsync();
        }
    }
}
