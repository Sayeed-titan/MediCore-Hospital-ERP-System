using Microsoft . AspNetCore . Mvc;
using Microsoft . EntityFrameworkCore;
using MediCore . API . Data;
using MediCore . API . Models;
using MediCore . API . DTOs;

namespace MediCore . API . Controllers
{
      [ApiController]
      [Route ( "api/[controller]" )]
      public class DoctorsController : ControllerBase
      {
            private readonly ApplicationDbContext _context;

            public DoctorsController ( ApplicationDbContext context )
            {
                  _context = context;
            }

            // GET: api/doctors
            [HttpGet]
            public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctors ( )
            {
                  var doctors = await _context.Doctors
                .Select(d => new DoctorDto
                {
                      Id = d.Id,
                      FirstName = d.FirstName,
                      LastName = d.LastName,
                      Specialization = d.Specialization,
                      Phone = d.Phone,
                      Email = d.Email
                })
                .ToListAsync();

                  return Ok ( doctors );
            }

            // GET: api/doctors/5
            [HttpGet ( "{id}" )]
            public async Task<ActionResult<DoctorDto>> GetDoctor ( int id )
            {
                  var doctor = await _context.Doctors.FindAsync(id);

                  if ( doctor == null )
                        return NotFound ( new { message = "Doctor not found" } );

                  var doctorDto = new DoctorDto
                  {
                        Id = doctor.Id,
                        FirstName = doctor.FirstName,
                        LastName = doctor.LastName,
                        Specialization = doctor.Specialization,
                        Phone = doctor.Phone,
                        Email = doctor.Email
                  };

                  return Ok ( doctorDto );
            }

            // POST: api/doctors
            [HttpPost]
            public async Task<ActionResult<DoctorDto>> CreateDoctor ( CreateDoctorDto createDto )
            {
                  var doctor = new Doctor
                  {
                        FirstName = createDto.FirstName,
                        LastName = createDto.LastName,
                        Specialization = createDto.Specialization,
                        Phone = createDto.Phone,
                        Email = createDto.Email,
                        CreatedAt = DateTime.UtcNow
                  };

                  _context . Doctors . Add ( doctor );
                  await _context . SaveChangesAsync ( );

                  var doctorDto = new DoctorDto
                  {
                        Id = doctor.Id,
                        FirstName = doctor.FirstName,
                        LastName = doctor.LastName,
                        Specialization = doctor.Specialization,
                        Phone = doctor.Phone,
                        Email = doctor.Email
                  };

                  return CreatedAtAction ( nameof ( GetDoctor ) , new { id = doctor . Id } , doctorDto );
            }

            // PUT: api/doctors/5
            [HttpPut ( "{id}" )]
            public async Task<IActionResult> UpdateDoctor ( int id , CreateDoctorDto updateDto )
            {
                  var doctor = await _context.Doctors.FindAsync(id);

                  if ( doctor == null )
                        return NotFound ( new { message = "Doctor not found" } );

                  doctor . FirstName = updateDto . FirstName;
                  doctor . LastName = updateDto . LastName;
                  doctor . Specialization = updateDto . Specialization;
                  doctor . Phone = updateDto . Phone;
                  doctor . Email = updateDto . Email;

                  await _context . SaveChangesAsync ( );

                  return NoContent ( );
            }

            // DELETE: api/doctors/5
            [HttpDelete ( "{id}" )]
            public async Task<IActionResult> DeleteDoctor ( int id )
            {
                  var doctor = await _context.Doctors.FindAsync(id);

                  if ( doctor == null )
                        return NotFound ( new { message = "Doctor not found" } );

                  _context . Doctors . Remove ( doctor );
                  await _context . SaveChangesAsync ( );

                  return NoContent ( );
            }
      }
}