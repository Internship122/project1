using javax.management.loading;
using Microsoft.EntityFrameworkCore;
using WebApplication1;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services.Files;
using WebApplication1.Services.Personnes;
using WebApplication1.Profiles;
using WebApplication1.GraphQl;
using Microsoft.AspNetCore.Http.Features;
using WebApplication1.GraphQl.Mutations;
using WebApplication1.GraphQl.Queries;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddCors(options =>
{
        options.AddDefaultPolicy(
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7144/Fileapi",
                                              "https://localhost:7144/Personneapi");
                      });
});
builder.Services.AddControllers().AddApplicationPart(typeof(WebApplication1.Controllers.FileController).Assembly);
builder.Services.AddControllers().AddApplicationPart(typeof(WebApplication1.Controllers.PersonneController).Assembly);
builder.Services.AddScoped<IPersonneService, PersonneService>();
builder.Services.AddScoped<IFileService,  FileService>();
builder.Services.AddAuthorization();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection") 
    ));
builder.Services.AddAutoMapper(typeof(PersonneProfile));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddTypeExtension<PersonneQuery>()
    .AddTypeExtension<PersonneMutation>()
    .AddType<PersonneType>()
                .AddProjections().AddAuthorizationCore().AddFiltering().AddSorting();

builder.Services.Configure<FormOptions>(options =>
{
    // Set the limit to 256 MB
    options.MultipartBodyLengthLimit = 268435456;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseRouting();

app.UseCors();

app.UseAuthorization();

app.UseEndpoints( endpoints => { endpoints.MapControllers(); endpoints.MapGraphQL("/GraphQL"); }
   );

app.Run();
