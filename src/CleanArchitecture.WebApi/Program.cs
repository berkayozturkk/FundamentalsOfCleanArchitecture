using CleanArchitecture.Persistance.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddControllers()
    .AddApplicationPart(
    typeof(CleanArchitecture.Presentation.AssemblyReferance).Assembly);

builder.Services.AddMediatR
    (cfr => cfr.RegisterServicesFromAssemblies(
        typeof(CleanArchitecture.Application.AssemblyReference).Assembly));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
