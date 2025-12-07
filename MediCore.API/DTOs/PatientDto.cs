namespace MediCore . API . DTOs
{
      public class PatientDto
      {
            public int Id { get; set; }
            public string FirstName { get; set; } = string . Empty;
            public string LastName { get; set; } = string . Empty;
            public DateTime DateOfBirth { get; set; }
            public string Gender { get; set; } = string . Empty;
            public string Phone { get; set; } = string . Empty;
            public string Email { get; set; } = string . Empty;
            public string Address { get; set; } = string . Empty;
      }

      public class CreatePatientDto
      {
            public string FirstName { get; set; } = string . Empty;
            public string LastName { get; set; } = string . Empty;
            public DateTime DateOfBirth { get; set; }
            public string Gender { get; set; } = string . Empty;
            public string Phone { get; set; } = string . Empty;
            public string Email { get; set; } = string . Empty;
            public string Address { get; set; } = string . Empty;
      }
}