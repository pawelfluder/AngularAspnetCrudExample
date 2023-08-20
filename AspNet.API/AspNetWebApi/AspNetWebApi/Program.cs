using AspNetWebApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("PersonContext");
builder.Services.AddDbContext<FullStackDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDbContext<FullStackDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PersonContext"));
        //sqlServerOptionsAction: SqlOptions =>
        //{
        //    SqlOptions.EnableRetryOnFailure(
        //        maxRetryCount: 10,
        //        maxRetryDelay: TimeSpan.FromSeconds(30),
        //        errorNumbersToAdd: null);
        //});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapGet("testing01", () =>
{
    Console.WriteLine("testing01");
});

app.UseAuthorization();
app.MapControllers();

app.Run();
