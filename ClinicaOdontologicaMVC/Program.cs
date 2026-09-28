using ClinicaOdontologica.Consumer;
using ClinicaOdontologicaModelos;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

CRUD<Consultorio>.Endpoint = "https://localhost:7056/api/Consultorios";
CRUD<Cita>.Endpoint = "https://localhost:7056/api/Citas";
CRUD<Especialidad>.Endpoint = "https://localhost:7056/api/Especialidades";
CRUD<Factura>.Endpoint = "https://localhost:7056/api/Facturas";
CRUD<Odontologo>.Endpoint = "https://localhost:7056/api/Odontologos";
CRUD<Paciente>.Endpoint = "https://localhost:7056/api/Pacientes";
CRUD<Receta>.Endpoint = "https://localhost:7056/api/Recetas";
CRUD<Tratamiento>.Endpoint = "https://localhost:7056/api/Tratamientos";
CRUD<DetalleCita>.Endpoint = "https://localhost:7056/api/DetallesCitas";
CRUD<HistorialMedico>.Endpoint = "https://localhost:7056/api/HistorialMedicos";




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();