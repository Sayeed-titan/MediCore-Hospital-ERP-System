using Microsoft . AspNetCore . Mvc;
using Microsoft . EntityFrameworkCore;
using MediCore . API . Data;
using MediCore . API . Models;
using MediCore . API . DTOs;

namespace MediCore . API . Controllers
{
      [ApiController]
      [Route ( "api/[controller]" )]
      public class AppointmentsController : ControllerBase
      {
            private readonly ApplicationDbContext _context;

            public AppointmentsController ( ApplicationDbContext context )
            {
                  _context = context;
            }

            // GET: api/appointments
            [HttpGet]
            public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAppointments ( )
            {
                  var appointments = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Select(a => new AppointmentDto
                {
                      Id = a.Id,
                      PatientId = a.PatientId,
                      PatientName = a.Patient.FirstName + " " + a.Patient.LastName,
                      DoctorId = a.DoctorId,
                      DoctorName = a.Doctor.FirstName + " " + a.Doctor.LastName,
                      DoctorSpecialization = a.Doctor.Specialization,
                      AppointmentDate = a.AppointmentDate,
                      AppointmentTime = a.AppointmentTime,
                      Status = a.Status,
                      Notes = a.Notes
                })
                .OrderByDescending(a => a.AppointmentDate)
                .ToListAsync();

                  return Ok ( appointments );
            }

            // GET: api/appointments/5
            [HttpGet ( "{id}" )]
            public async Task<ActionResult<AppointmentDto>> GetAppointment ( int id )
            {
                  var appointment = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync(a => a.Id == id);

                  if ( appointment == null )
                        return NotFound ( new { message = "Appointment not found" } );

                  var appointmentDto = new AppointmentDto
                  {
                        Id = appointment.Id,
                        PatientId = appointment.PatientId,
                        PatientName = appointment.Patient.FirstName + " " + appointment.Patient.LastName,
                        DoctorId = appointment.DoctorId,
                        DoctorName = appointment.Doctor.FirstName + " " + appointment.Doctor.LastName,
                        DoctorSpecialization = appointment.Doctor.Specialization,
                        AppointmentDate = appointment.AppointmentDate,
                        AppointmentTime = appointment.AppointmentTime,
                        Status = appointment.Status,
                        Notes = appointment.Notes
                  };

                  return Ok ( appointmentDto );
            }

            // POST: api/appointments
            [HttpPost]
            public async Task<ActionResult<AppointmentDto>> CreateAppointment ( CreateAppointmentDto createDto )
            {
                  try
                  {
                        var appointment = new Appointment
                        {
                              PatientId = createDto.PatientId,
                              DoctorId = createDto.DoctorId,
                              AppointmentDate = createDto.AppointmentDate,
                              AppointmentTime = createDto.AppointmentTime,  // Direct assignment now!
                              Status = "Scheduled",
                              Notes = createDto.Notes,
                              CreatedAt = DateTime.UtcNow
                        };

                        _context . Appointments . Add ( appointment );
                        await _context . SaveChangesAsync ( );

                        // Load related data
                        await _context . Entry ( appointment ) . Reference ( a => a . Patient ) . LoadAsync ( );
                        await _context . Entry ( appointment ) . Reference ( a => a . Doctor ) . LoadAsync ( );

                        var appointmentDto = new AppointmentDto
                        {
                              Id = appointment.Id,
                              PatientId = appointment.PatientId,
                              PatientName = appointment.Patient.FirstName + " " + appointment.Patient.LastName,
                              DoctorId = appointment.DoctorId,
                              DoctorName = appointment.Doctor.FirstName + " " + appointment.Doctor.LastName,
                              DoctorSpecialization = appointment.Doctor.Specialization,
                              AppointmentDate = appointment.AppointmentDate,
                              AppointmentTime = appointment.AppointmentTime,
                              Status = appointment.Status,
                              Notes = appointment.Notes
                        };

                        return CreatedAtAction ( nameof ( GetAppointment ) , new { id = appointment . Id } , appointmentDto );
                  }
                  catch ( Exception ex )
                  {
                        Console . WriteLine ( $"Error: {ex . Message}" );
                        return StatusCode ( 500 , new { error = ex . Message } );
                  }
            }

            // PATCH: api/appointments/5/status
            [HttpPatch ( "{id}/status" )]
            public async Task<IActionResult> UpdateAppointmentStatus ( int id , UpdateAppointmentStatusDto updateDto )
            {
                  var appointment = await _context.Appointments.FindAsync(id);

                  if ( appointment == null )
                        return NotFound ( new { message = "Appointment not found" } );

                  appointment . Status = updateDto . Status;
                  await _context . SaveChangesAsync ( );

                  return NoContent ( );
            }

            // DELETE: api/appointments/5
            [HttpDelete ( "{id}" )]
            public async Task<IActionResult> DeleteAppointment ( int id )
            {
                  var appointment = await _context.Appointments.FindAsync(id);

                  if ( appointment == null )
                        return NotFound ( new { message = "Appointment not found" } );

                  _context . Appointments . Remove ( appointment );
                  await _context . SaveChangesAsync ( );

                  return NoContent ( );
            }

            // GET: api/appointments/stats
            [HttpGet ( "stats" )]
            public async Task<ActionResult<object>> GetStats ( )
            {
                  try
                  {
                        var totalPatients = await _context.Patients.CountAsync();
                        var totalDoctors = await _context.Doctors.CountAsync();
                        var totalAppointments = await _context.Appointments.CountAsync();
                        var today = DateTime.UtcNow.Date;
                        var todayAppointments = await _context.Appointments
                    .CountAsync(a => a.AppointmentDate.Date == today);

                        return Ok ( new
                        {
                              totalPatients ,
                              totalDoctors ,
                              totalAppointments ,
                              todayAppointments
                        } );
                  }
                  catch ( Exception ex )
                  {
                        Console . WriteLine ( $"Stats error: {ex . Message}" );
                        return StatusCode ( 500 , new { error = ex . Message } );
                  }
            }
      }
}