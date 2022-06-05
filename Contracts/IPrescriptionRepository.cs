using Entities.Models;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPrescriptionRepository : IRepositoryBase<Prescription>
    {
        public Task<Prescription> GetPrescriptionWithDetailsByIdAsync(int id);
    }
}
