using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VentasDale.Api.Configurations;
using VentasDale.Persistence;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddCors();
builder.Services.AddInterfacesInjection();
builder.Services.AddDbContext<DbApiContext>(options =>
{
    options.UseSqlServer("Data Source=(local);Initial Catalog=VentasST;Integrated Security=True;");
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// global cors policy
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    ); // allow credentials

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
