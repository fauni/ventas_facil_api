using BusinessLogic.Logic;
using Core.Interfaces;
using Data.Implementation;
using Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserData, UserData>();

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyData, CompanyData>();
builder.Services.AddScoped<IItemData, ItemData>();

//Socio de Negocio
builder.Services.AddScoped<IBusinessPartnersRepository, BusinessPartnersRepository>();

//Condiciones de Pago
builder.Services.AddScoped<IPaymentTermsTypesRepository, PaymentTermsTypesRepository>();

//Contact Employees
builder.Services.AddScoped<IContactEmployeeRepository, ContactEmployeeRepository>();

//Direccion Cliente
builder.Services.AddScoped<IBPAdressRepository, BPAdressRepository>();

//Items
builder.Services.AddScoped<IItemRepository, ItemRepository>();
//Item Group
builder.Services.AddScoped<IItemGroupRepository, ItemGroupRepository>();

// Ventas
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
// Personal de Ventas
builder.Services.AddScoped<ISalesPersonsRepository, SalesPersonsRepository>();

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
