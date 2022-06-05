using Entities.Models;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDoctorRepository : IRepositoryBase<Doctor>
    {
        public Task<Doctor> GetByIdAsync(int id);
        public void UpdateDoctor(Doctor doctor);
        public void CreateDoctor(Doctor doctor);
        public void DeleteDoctor(Doctor doctor);
    }
}
