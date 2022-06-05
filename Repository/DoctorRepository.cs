using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Repository
{
    public class DoctorRepository : RepositoryBase<Doctor>, IDoctorRepository
    {
        private readonly DBContext _context;
        public DoctorRepository(DBContext context) : base(context)
        {
            _context = context;
        }

        public void CreateDoctor(Doctor doctor)
        {
            Create(doctor);
        }

        public void DeleteDoctor(Doctor doctor)
        {
            Delete(doctor);
        }

        public Task<Doctor> GetByIdAsync(int id)
        {
            return GetByCondition(e => e.IdDoctor == id).FirstOrDefaultAsync();
        }

        public void UpdateDoctor(Doctor doctor)
        {
            Update(doctor);
        }
    }
}
