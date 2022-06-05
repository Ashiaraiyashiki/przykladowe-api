using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IDoctorRepository Doctor { get; }
        IPrescriptionRepository Prescription { get; }
        Task SaveAsync();
    }
}
