using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using przykladowe_api.DTOs;
using System.Linq;
using System.Threading.Tasks;

namespace przykladowe_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        public PrescriptionsController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWithDetailsById(int id)
        {
            var prescriptionWithDetails = await _repository.Prescription.GetPrescriptionWithDetailsByIdAsync(id);

            if (prescriptionWithDetails is null) 
                return NotFound();

            return Ok(new PrescriptionGet
            {
                ID = prescriptionWithDetails.IdPrescription,
                Date = prescriptionWithDetails.Date,
                DueDate = prescriptionWithDetails.DueDate,
                DoctorFirstName = prescriptionWithDetails.Doctor.FirstName,
                DoctorLastName = prescriptionWithDetails.Doctor.LastName,
                PatientFirstName = prescriptionWithDetails.Patient.FirstName,
                PatientLastName = prescriptionWithDetails.Patient.LastName,
                Medicaments = prescriptionWithDetails.PrescriptionMedicaments.Select(e =>
                new PrescriptionGetMedicament
                {
                    Name = e.Medicament.Name,
                    Dose = e.Dose,
                    Details = e.Details
                }).ToList()
            });
        }
    }
}
