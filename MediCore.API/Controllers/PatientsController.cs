using Microsoft . AspNetCore . Mvc;
using Microsoft . EntityFrameworkCore;
using MediCore . API . Data;
using MediCore . API . Models;
using MediCore . API . DTOs;

namespace MediCore . API . Controllers
{
      [ApiController]
      [Route ( "api/[controller]" )]
      public class PatientsController : ControllerBase
      {
            private readonly ApplicationDbContext _context;

            public PatientsController ( ApplicationDbContext context )
            {
                  _context = context;
            }

            // GET: api/patients
            [HttpGet]
            public async Task<ActionResult<IEnumerable<PatientDto>>> GetPatients ( )
            {
                  var patients = await _context.Patients
                .Select(p => new PatientDto
                {
                      Id = p.Id,
                      FirstName = p.FirstName,
                      LastName = p.LastName,
                      DateOfBirth = p.DateOfBirth,
                      Gender = p.Gender,
                      Phone = p.Phone,
                      Email = p.Email,
                      Address = p.Address
                })
                .ToListAsync();

                  return Ok ( patients );
            }

            // GET: api/patients/5
            [HttpGet ( "{id}" )]
            public async Task<ActionResult<PatientDto>> GetPatient ( int id )
            {
                  var patient = await _context.Patients.FindAsync(id);

                  if ( patient == null )
                        return NotFound ( new { message = "Patient not found" } );

                  var patientDto = new PatientDto
                  {
                        Id = patient.Id,
                        FirstName = patient.FirstName,
                        LastName = patient.LastName,
                        DateOfBirth = patient.DateOfBirth,
                        Gender = patient.Gender,
                        Phone = patient.Phone,
                        Email = patient.Email,
                        Address = patient.Address
                  };

                  return Ok ( patientDto );
            }

            // POST: api/patients
            [HttpPost]
            public async Task<ActionResult<PatientDto>> CreatePatient ( CreatePatientDto createDto )
            {
                  try
                  {
                        var patient = new Patient
                        {
                              FirstName = createDto.FirstName,
                              LastName = createDto.LastName,
                              DateOfBirth = createDto.DateOfBirth,
                              Gender = createDto.Gender,
                              Phone = createDto.Phone,
                              Email = createDto.Email,
                              Address = createDto.Address,
                              CreatedAt = DateTime.UtcNow
                        };

                        _context . Patients . Add ( patient );
                        await _context . SaveChangesAsync ( );

                        var patientDto = new PatientDto
                        {
                              Id = patient.Id,
                              FirstName = patient.FirstName,
                              LastName = patient.LastName,
                              DateOfBirth = patient.DateOfBirth,
                              Gender = patient.Gender,
                              Phone = patient.Phone,
                              Email = patient.Email,
                              Address = patient.Address
                        };

                        return CreatedAtAction ( nameof ( GetPatient ) , new { id = patient . Id } , patientDto );
                  }
                  catch ( Exception ex )
                  {
                        // Log the actual error
                        Console . WriteLine ( $"Error creating patient: {ex . Message}" );
                        Console . WriteLine ( $"Inner Exception: {ex . InnerException?.Message}" );
                        return StatusCode ( 500 , new
                        {
                              message = "Error creating patient" ,
                              error = ex . Message ,
                              innerError = ex . InnerException?.Message
                        } );
                  }
            }

            // PUT: api/patients/5
            [HttpPut ( "{id}" )]
            public async Task<IActionResult> UpdatePatient ( int id , CreatePatientDto updateDto )
            {
                  var patient = await _context.Patients.FindAsync(id);

                  if ( patient == null )
                        return NotFound ( new { message = "Patient not found" } );

                  patient . FirstName = updateDto . FirstName;
                  patient . LastName = updateDto . LastName;
                  patient . DateOfBirth = updateDto . DateOfBirth;
                  patient . Gender = updateDto . Gender;
                  patient . Phone = updateDto . Phone;
                  patient . Email = updateDto . Email;
                  patient . Address = updateDto . Address;

                  await _context . SaveChangesAsync ( );

                  return NoContent ( );
            }

            // DELETE: api/patients/5
            [HttpDelete ( "{id}" )]
            public async Task<IActionResult> DeletePatient ( int id )
            {
                  var patient = await _context.Patients.FindAsync(id);

                  if ( patient == null )
                        return NotFound ( new { message = "Patient not found" } );

                  _context . Patients . Remove ( patient );
                  await _context . SaveChangesAsync ( );

                  return NoContent ( );
            }
      }
}