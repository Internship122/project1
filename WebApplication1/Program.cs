using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services.Files;
using WebApplication1.Services.Personnes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddApplicationPart(typeof(WebApplication1.Controllers.FileController).Assembly);
builder.Services.AddControllers().AddApplicationPart(typeof(WebApplication1.Controllers.PersonneController).Assembly);
builder.Services.AddScoped<IPersonneService, PersonneService>();
builder.Services.AddScoped<IFileService,  FileService>();
builder.Services.AddAuthorization();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection") 
    ));
builder.Services.AddAutoMapper(typeof(Program), typeof(PersonnneProfile));
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

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints( endpoints => { endpoints.MapControllers(); }
   );

app.Run();
