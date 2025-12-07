using Microsoft . EntityFrameworkCore;
using MediCore . API . Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder . Services . AddControllers ( );
builder . Services . AddEndpointsApiExplorer ( );
builder . Services . AddSwaggerGen ( );

AppContext . SetSwitch ( "Npgsql.EnableLegacyTimestampBehavior" , true );

// Configure PostgreSQL
builder . Services . AddDbContext<ApplicationDbContext> ( options =>
    options . UseNpgsql ( builder . Configuration . GetConnectionString ( "DefaultConnection" ) ) );

// Configure CORS
builder . Services . AddCors ( options =>
{
      options . AddPolicy ( "AllowReactApp" ,
          builder => builder
              . WithOrigins ( "http://localhost:5173" , "http://localhost:3000" , "http://localhost:5174" )
              . AllowAnyMethod ( )
              . AllowAnyHeader ( ) );
} );

var app = builder.Build();

// Configure the HTTP request pipeline
if ( app . Environment . IsDevelopment ( ) )
{
      app . UseSwagger ( );
      app . UseSwaggerUI ( );
}

app . UseCors ( "AllowReactApp" );
app . UseAuthorization ( );
app . MapControllers ( );

app . Run ( );
