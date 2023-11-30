using Microsoft.EntityFrameworkCore;
using Serilog;
using Trolley.API.Data;
using Trolley.API.Mapper;
using Trolley.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add Logger.
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
    .MinimumLevel.Debug()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Register AutoMapper.
builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Register Services.
builder.Services.AddScoped<IShoppingListService, ShoppingListService>();
builder.Services.AddScoped<ProductService>();


// Add DbContext to the container.
builder.Services.AddDbContext<TrolleyDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Controllers to the container.
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
