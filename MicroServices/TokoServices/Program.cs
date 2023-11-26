using Microsoft.EntityFrameworkCore;
using TokoServices.Model;
using TokoServices.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ITokoServices, TokoService>();
builder.Services.AddDbContext<TokoAppContext>(opt =>
{
    IConfiguration cfg = builder.Configuration;
    opt.UseSqlServer(cfg.GetConnectionString("DBConn"));
});
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
