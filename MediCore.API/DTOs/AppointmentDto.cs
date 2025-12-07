namespace MediCore . API . DTOs
{
      public class AppointmentDto
      {
            public int Id { get; set; }
            public int PatientId { get; set; }
            public string PatientName { get; set; } = string . Empty;
            public int DoctorId { get; set; }
            public string DoctorName { get; set; } = string . Empty;
            public string DoctorSpecialization { get; set; } = string . Empty;
            public DateTime AppointmentDate { get; set; }
            public string AppointmentTime { get; set; } = string . Empty;
            public string Status { get; set; } = string . Empty;
            public string Notes { get; set; } = string . Empty;
      }

      public class CreateAppointmentDto
      {
            public int PatientId { get; set; }
            public int DoctorId { get; set; }
            public DateTime AppointmentDate { get; set; }

            public string AppointmentTime { get; set; } = string . Empty;
            public string Notes { get; set; } = string . Empty;
      }

      public class UpdateAppointmentStatusDto
      {
            public string Status { get; set; } = string . Empty;
      }
}