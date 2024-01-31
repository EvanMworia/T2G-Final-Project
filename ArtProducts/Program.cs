using ArtProducts.Database;
using ArtProducts.Extensions;
using ArtProducts.Services;
using ArtProducts.Services.IServices;
using AuthMS.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AddAuth();
builder.AddSwaggenGenExtension();

//----------REGISTERING OUR SERVICES FOR DEPENDENCY INJECTION------------------

//------2. THE DATABASE CONNECTION------------
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("myConnString"));
});
//-------3. OUR INTERFACES AND THEIR SERVICE IMPLEMENTATION
builder.Services.AddScoped<IProducts, ProductServices>();

//------4. AUTO MAPPER--------------------
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//------REGISTER OUR SERVICE FOR AUTOMATIC PENDING MIGRATIONS TO BE APPLIED 
app.UseMigrations();
//----------------

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
