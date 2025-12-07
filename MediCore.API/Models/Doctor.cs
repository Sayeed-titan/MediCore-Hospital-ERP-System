namespace MediCore . API . Models
{
      public class Doctor
      {
            public int Id { get; set; }
            public string FirstName { get; set; } = string . Empty;
            public string LastName { get; set; } = string . Empty;
            public string Specialization { get; set; } = string . Empty;
            public string Phone { get; set; } = string . Empty;
            public string Email { get; set; } = string . Empty;
            public DateTime CreatedAt { get; set; } = DateTime . UtcNow;
            public ICollection<Appointment> Appointments { get; set; } = new List<Appointment> ( );
      }
}
