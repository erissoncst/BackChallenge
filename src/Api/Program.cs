using Infrastructure.Persistence;
using FluentValidation;
using Api;
using Application.CheckIns.Command.SaveCheckIn;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseCors(builder => builder.AllowAnyOrigin());

app.MapControllers();

var scope = app.Services.CreateScope();
var ctx = scope.ServiceProvider.GetRequiredService<DataContext>();
await DataContextSeed.SeedSampleDataAsync(ctx);


app.Run();
