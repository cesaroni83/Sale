using Microsoft.EntityFrameworkCore;
using Sale.Api.AutoMapper;
using Sale.Api.Data;
using Sale.Api.Intefaz;
using Sale.Api.Intefaz.Implementacion;
using Sale.Api.Servicios;
using Sale.Api.Servicios.Implementacion;
using Sale.Api.SolidWorks;
using Sale.Api.SolidWorks.Implementacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSql"));
});

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddTransient(typeof(IGenericoModelo<>), typeof(GenericoModelo<>));
builder.Services.AddScoped<IPaises, Paises>();
builder.Services.AddScoped<IProvincias, Provincias>();
builder.Services.AddScoped<ICiudades, Ciudades>();
builder.Services.AddScoped<IEmpresas, Empresas>();
builder.Services.AddScoped<ISucursales, Sucursales>();
builder.Services.AddScoped<IPersonas, Personas>();
builder.Services.AddScoped<IMenus, Menus>();
builder.Services.AddScoped<ISolidWorksFile, SolidworksFile>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(x => x
.AllowAnyMethod()
.AllowAnyHeader()
.SetIsOriginAllowed(origin => true)
.AllowCredentials());


app.Run();
