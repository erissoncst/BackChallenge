using Infrastructure.Persistence;
using MediatR;
using System.Reflection;
using Application.Categories.Queries.ListCategories;
using Application.Categories.Command.SimulationCategoriesCommand;
using Application.CheckIns.Command.SaveCheckIn;
using Application.Common.Behaviours;
using FluentValidation;
using FluentValidation.AspNetCore;
using Api.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddMediatR(typeof(ListCategoryQuery).Assembly);
builder.Services.AddMediatR(typeof(SimulationCategoriesCommand).Assembly);
builder.Services.AddMediatR(typeof(SaveCheckInsCommand).Assembly);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
builder.Services.AddControllersWithViews(options =>
            options.Filters.Add<ApiExceptionFilterAttribute>())
                .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

AssemblyScanner.FindValidatorsInAssembly(typeof(SaveCheckOutCommandValidator).Assembly)
  .ForEach(item => builder.Services.AddScoped(item.InterfaceType, item.ValidatorType));

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var scope = app.Services.CreateScope();
var ctx = scope.ServiceProvider.GetRequiredService<DataContext>();
await DataContextSeed.SeedSampleDataAsync(ctx);

app.Run();
