using Parcial02_BM101219_JP100320.Models;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//PROGRAM.CS

builder.Services.AddCors(options =>

{

    options.AddPolicy(name:MyAllowSpecificOrigins, builder =>

    {

        builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();


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



app.UseCors(MyAllowSpecificOrigins); //programs.cs
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
