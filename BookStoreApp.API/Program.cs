using BookStoreApp.API.Data;
using Microsoft.EntityFrameworkCore;
using BookStoreApp.API.Controllers;
//Serilog is something for logging it
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("BookStoreAppDBConnection");
builder.Services.AddDbContext<CsharpdemodbContext>(options => options.UseNpgsql(connString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Solve the CORS problems
builder.Services.AddCors( options =>
{
    //We create a policy and give it a name
    options.AddPolicy("AllowAll", b => b.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//Use the policy we just created.
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();


app.Run();
