namespace MediCore . API . Models
{
      public class Appointment
      {
            public int Id { get; set; }
            public int PatientId { get; set; }
            public int DoctorId { get; set; }
            public DateTime AppointmentDate { get; set; }
            public string AppointmentTime { get; set; } = string . Empty;  
            public string Status { get; set; } = "Scheduled"; // Scheduled, Completed, Cancelled
            public string Notes { get; set; } = string . Empty;
            public DateTime CreatedAt { get; set; } = DateTime . UtcNow;
            public Patient Patient { get; set; } = null!;
            public Doctor Doctor { get; set; } = null!;
      }
}
