using Microsoft.EntityFrameworkCore;
using ProgramsManager.BL.Interfaces;
using ProgramsManager.BL.Resources;
using ProgramsManager.DAL.Database;
using ProgramsManager.DAL.Interfaces;
using ProgramsManager.DAL.Resources;
using ProgramsManager.Models.Models.Menu;
using ProgramsManager.Models.Models.Order;
using ProgramsManager.Models.Models.Plate;
using ProgramsManager.Models.Models.Restaurant;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
