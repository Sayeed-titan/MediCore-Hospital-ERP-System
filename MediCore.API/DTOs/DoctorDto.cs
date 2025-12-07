namespace MediCore . API . DTOs
{
      public class DoctorDto
      {
            public int Id { get; set; }
            public string FirstName { get; set; } = string . Empty;
            public string LastName { get; set; } = string . Empty;
            public string Specialization { get; set; } = string . Empty;
            public string Phone { get; set; } = string . Empty;
            public string Email { get; set; } = string . Empty;
      }

      public class CreateDoctorDto
      {
            public string FirstName { get; set; } = string . Empty;
            public string LastName { get; set; } = string . Empty;
            public string Specialization { get; set; } = string . Empty;
            public string Phone { get; set; } = string . Empty;
            public string Email { get; set; } = string . Empty;
      }
}