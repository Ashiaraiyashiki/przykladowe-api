using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly DBContext _context;
        private IDoctorRepository _doctor;
        private IPrescriptionRepository _prescription;
        public IDoctorRepository Doctor { 
            get {
                if(_doctor is null)
                {
                    _doctor = new DoctorRepository(_context);
                }
                return _doctor;
            }
        }
        public IPrescriptionRepository Prescription {
            get
            {
                if (_prescription is null)
                {
                    _prescription = new PrescriptionRepository(_context);
                }
                return _prescription;
            }
        }

        public RepositoryWrapper(DBContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
