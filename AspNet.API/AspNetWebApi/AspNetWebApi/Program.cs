using AspNetWebApi.Data;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var myLocalHost7066 = "myLocalHost7066";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myLocalHost7066, policy =>
    {
        policy.WithOrigins("http://localhost:7066")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});


builder.Services.AddDbContext<FullStackDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FullStackConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("testing01", () =>
{
    Console.WriteLine("testing01");
});

app.UseAuthorization();

app.Run();

//IServerAddressesFeature addressFeature = null;
//app.MapGet("/", () => $"Hi there, Kestrel is running on\n\n{string.Join("\n", addressFeature.Addresses.ToArray())} ");
//app.Start();

//var server = app.Services.GetService<IServer>();
//addressFeature = server.Features.Get<IServerAddressesFeature>();

//foreach (var address in addressFeature.Addresses)
//{
//    Console.WriteLine("Kestrel is listening on address: " + address);
//}

//app.WaitForShutdown();
