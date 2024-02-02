using BiddingMS.Data;
using BiddingMS.Extensions;
using BiddingMS.Services;
using BiddingMS.Services.IService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AddAuth();
builder.AddSwaggenGenExtension();
//---------------Configuring connectionString to our database-------
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("myConnString"));
});
//-------3. OUR INTERFACES AND THEIR SERVICE IMPLEMENTATION
builder.Services.AddScoped<IBidding, BiddingService>();
builder.Services.AddScoped<IProduct, ProductService>();
// Base_url/{prodct_id}/{amount}

//------4. AUTO MAPPER--------------------
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//----------------OUR EXTERNAL HTTP CLIENT AND BASE URL-----------
builder.Services.AddHttpClient("Product", productFetcher => productFetcher.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ServiceURl:ProgramService")));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMigrations();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
