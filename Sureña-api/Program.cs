using Sureña_api.Modelos.Repositorio;
using Microsoft.EntityFrameworkCore;
using Sureña_api.Modelos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SureñaContext>();
builder.Services.AddTransient<ICargo, CargoRepositorio>();
//builder.Services.AddTransient<IFunciones, FuncionesRepositorio>();
//builder.Services.AddTransient<IManual, ManualRepositorio>();
//builder.Services.AddTransient<IRelaciones, RelacionesRepositorio>();
//builder.Services.AddTransient<IUsuarios, UsuariosRepositorio>();

//services cors 

builder.Services.AddCors(options =>

{

    options.AddDefaultPolicy(

              builder =>

              {

                  builder.WithOrigins("http://localhost/*", "http://localhost:5500/*")

                  //   builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost") 



                  .AllowAnyOrigin()

                  .AllowAnyHeader()

                  .AllowAnyMethod();





              });



});

var app = builder.Build();
app.UseCors();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
