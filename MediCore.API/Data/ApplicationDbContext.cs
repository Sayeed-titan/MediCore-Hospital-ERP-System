using MediCore . API . Models;

using Microsoft . EntityFrameworkCore;


namespace MediCore . API . Data
{
      public class ApplicationDbContext : DbContext
      {
            public ApplicationDbContext ( DbContextOptions < ApplicationDbContext > options ) : base ( options )
            {
            }

            public DbSet<Patient> Patients { get; set; }
            public DbSet<Doctor> Doctors { get; set; }
            public DbSet<Appointment> Appointments { get; set; }

            protected override void OnModelCreating ( ModelBuilder modelBuilder )
            {
                  base . OnModelCreating ( modelBuilder );

                  // Patient entity configuration
                  modelBuilder . Entity<Patient> ( entity =>
                  {
                        entity.HasKey ( e => e . Id );
                        entity . Property ( e => e . FirstName ) . IsRequired ( ) . HasMaxLength ( 50 );
                        entity . Property ( e => e . LastName ) . IsRequired ( ) . HasMaxLength ( 50 );
                        entity.Property( e => e.Gender ).HasMaxLength ( 10 );
                        entity . Property ( e => e . Phone ) . HasMaxLength ( 20 );
                        entity .Property( e => e.Email ).HasMaxLength ( 100 );

                  } );

                  // Doctor configuration
                  modelBuilder . Entity<Doctor> ( entity =>
                  {
                        entity . HasKey ( e => e . Id );
                        entity . Property ( e => e . FirstName ) . IsRequired ( ) . HasMaxLength ( 50 );
                        entity . Property ( e => e . LastName ) . IsRequired ( ) . HasMaxLength ( 50 );
                        entity . Property ( e => e . Specialization ) . HasMaxLength ( 100 );
                        entity . Property ( e => e . Phone ) . HasMaxLength ( 20 );
                        entity . Property ( e => e . Email ) . HasMaxLength ( 100 );
                  } );

                  // Appointment configuration
                  modelBuilder . Entity<Appointment> ( entity =>
                  {
                        entity.HasKey ( e => e . Id );
                        entity.Property ( e => e . Status ) . IsRequired ( ) . HasMaxLength ( 20 );
                        entity . Property ( e => e . AppointmentTime ) . HasMaxLength ( 10 );

                        entity .HasOne ( e => e.Patient)
                              .WithMany ( p => p.Appointments )
                              .HasForeignKey ( e => e.PatientId )
                              .OnDelete ( DeleteBehavior . Cascade );

                        entity.HasOne ( e => e.Doctor )
                              .WithMany ( d => d.Appointments )
                              .HasForeignKey ( e => e.DoctorId )
                              .OnDelete ( DeleteBehavior . Cascade );
                  } );

                  // Seed initial data
                  modelBuilder . Entity<Doctor> ( ) . HasData (
                      new Doctor
                      {
                            Id = 1 ,
                            FirstName = "John" ,
                            LastName = "Smith" ,
                            Specialization = "Cardiology" ,
                            Phone = "123-456-7890" ,
                            Email = "john.smith@medicore.com" ,
                            CreatedAt = DateTime . UtcNow
                      } ,
                      new Doctor
                      {
                            Id = 2 ,
                            FirstName = "Sarah" ,
                            LastName = "Johnson" ,
                            Specialization = "Pediatrics" ,
                            Phone = "123-456-7891" ,
                            Email = "sarah.johnson@medicore.com" ,
                            CreatedAt = DateTime . UtcNow
                      }
                  );




            }


      }
}
