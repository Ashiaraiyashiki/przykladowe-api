using System;
using System.Collections.Generic;

namespace przykladowe_api.DTOs
{
    public class PrescriptionGet
    {
        public int ID { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public List<PrescriptionGetMedicament> Medicaments { get; set; }
    }

    public class PrescriptionGetMedicament
    {
        public string Name { get; set; }
        public int Dose { get; set; }
        public string Details { get; set; }
    }
}
