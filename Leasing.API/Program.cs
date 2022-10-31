using Leasing.API.App.Domain.Core;
using Leasing.API.App.Domain.Models;
using Leasing.API.App.Domain.Repository;
using Leasing.API.App.Persistence.Repositories;
using Leasing.API.App.Services;
using Leasing.API.App.Shared.Persistence.Contexts;
using Leasing.API.Shared.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen();

//Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());
// Add lower case routes
builder.Services.AddRouting(
    options => options.LowercaseUrls = true);
// CORS Service addition


builder.Services.AddCors();

// Dependency Injection Configuration

builder.Services.AddScoped<IAssetTypeRepository, AssetTypeRepository>();
builder.Services.AddScoped<IAssetTypeService, AssetTypeService>();

builder.Services.AddScoped<ICurrencyTypeRepository, CurrencyTypeRepository>();
builder.Services.AddScoped<ICurrencyTypeService, CurrencyTypeService>();

builder.Services.AddScoped<IFeeRepository, FeeRepository>();
builder.Services.AddScoped<IFeeService, FeeService>();

builder.Services.AddScoped<IFeeTypeRepository, FeeTypeRepository>();
builder.Services.AddScoped<IFeeTypeService, FeeTypeService>();

builder.Services.AddScoped<IPeriodRepository, PeriodRepository>();
builder.Services.AddScoped<IPeriodService, PeriodService>();

builder.Services.AddScoped<IRateTypeRepository, RateTypeRepository>();
builder.Services.AddScoped<IRateTypeService, RateTypeService>();

builder.Services.AddScoped<ISolutionRepository, SolutionRepository>();
builder.Services.AddScoped<ISolutionService, SolutionService>();

builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// AutoMapper Configuration


builder.Services.AddAutoMapper(
    typeof(Leasing.API.App.Mapping.ModelToResourceProfile),
    typeof(Leasing.API.App.Mapping.ResourceToModelProfile));

var app = builder.Build();

// Validation for Ensuring Database Objects are created

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure CORS

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();