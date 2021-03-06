using Models;
using VGame.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// MSSQL server
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Allow anything 
builder.Services.AddCors(options =>
{
  options.AddPolicy(name: "AppCors",
      policy =>
      {
        policy.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod();
      });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AppCors");
app.UseAuthorization();

app.MapControllers();

app.Run();
