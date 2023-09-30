using Parcial02_BM101219_JP100320.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//PROGRAM.CS

builder.Services.AddCors(options =>

{

    options.AddPolicy("MyPolicy", builder =>

    {

        builder.WithOrigins("http://localhost:4200")

            .AllowAnyMethod()

            .AllowAnyHeader()

            .AllowCredentials();

    });

});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<Bm101219Jp100320Context>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors("MyPolicy"); //programs.cs
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
