using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using Trolley.API.Data;
using Trolley.API.Entities;
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

// Adds Identity services to the services container
builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole<int>>()
    .AddTokenProvider<DataProtectorTokenProvider<User>>("Trolley")
    .AddEntityFrameworkStores<TrolleyDbContext>()
    .AddDefaultTokenProviders();



builder.Services.AddCors(options =>
{
    options.AddPolicy("TrolleyOrigins",
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});

//Identity Options
builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;
});


// Register Services.
builder.Services.AddScoped<IShoppingListService, ShoppingListService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<TokenService>();

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
    .AddIdentityCookies();
builder.Services.AddAuthorization();


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

// CORS-Middleware verwenden
app.UseCors("TrolleyOrigins");

// UseAuthentication muss vor UseAuthorization aufgerufen werden
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
