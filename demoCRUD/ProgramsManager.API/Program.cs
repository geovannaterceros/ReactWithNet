using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProgramsManager.BL.Interfaces;
using ProgramsManager.BL.Resources;
using ProgramsManager.DAL.Database;
using ProgramsManager.DAL.Interfaces;
using ProgramsManager.DAL.Resources;
using ProgramsManager.Models.Models.Menu;
using ProgramsManager.Models.Models.Order;
using ProgramsManager.Models.Models.Plate;
using ProgramsManager.Models.Models.Restaurant;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        ValidAudience = builder.Configuration["Authentication:Audience"],
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            builder.Configuration["Authentication:SecretKey"])),
        //Define el margen de tiempo
        ClockSkew = TimeSpan.Zero
      
    };
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
    });
});

// Add services to the containe.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DatabaseConfiguration
builder.Services.AddDbContext<ProjectContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectDB")));

//Data Access
builder.Services.AddScoped<IDataAccess<PlateDto>, PlateDataAccess>();
builder.Services.AddScoped<IDataAccess<RestaurantDto>, RestaurantDataAccess>();
builder.Services.AddScoped<IDataAccess<MenuDto>, MenuDataAccess>();
builder.Services.AddScoped<IDataAccess<OrderDto>, OrderDataAccess>();

//Bussiness Logic
builder.Services.AddScoped<IServices<PlateDto>, PlatesService>();
builder.Services.AddScoped<IServices<RestaurantDto>, RestaurantService>();
builder.Services.AddScoped<IServices<MenuDto>, MenuService>();
builder.Services.AddScoped<IServices<OrderDto>, OrderService>();

// Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web Service Api Restaurant", Version = "v2" });

    // Configuración del esquema Bearer
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "JWT Authorization header using the Bearer scheme",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
    };

    c.AddSecurityDefinition("Bearer", securityScheme);

    var securityRequirement = new OpenApiSecurityRequirement
    {
        { securityScheme, new List<string>() }
    };

    c.AddSecurityRequirement(securityRequirement);
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ProjectContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
