using Lab.Project.Api.Profiles;
using Lab.Project.Application.Services;
using Lab.Project.Application.UsesCases.Product.Queris;
using Lab.Project.Domain.Repositories;
using Lab.Project.Infraestructure.Repositories;
using Lab.Proyect.Api.Profiles;
using Lab.Proyect.Application.Services;
using Lab.Proyect.Domain.Repositories;
using Lab.Proyect.Infraestructure.Data;
using Lab.Proyect.Infraestructure.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Add DBContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProductFinalProyect;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
);

//Add Repositories
builder.Services.AddScoped<IProductRepository, ProductRepositories>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
//Add Services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();

//Add AutoMapper    
builder.Services.AddAutoMapper(typeof(ProductControllerProfile));
builder.Services.AddAutoMapper(typeof(CustomerProfile).Assembly);
builder.Services.AddAutoMapper(typeof(OrderProfile).Assembly);


//Add MediatR
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    config.RegisterServicesFromAssembly(typeof(ListCustomerQueries).Assembly);
});


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
