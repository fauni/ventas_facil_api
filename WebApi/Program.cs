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
// Item Unidad de Medida
builder.Services.AddScoped<IItemUnidadMedidaRepository, ItemUnidadMedidaRepository>();

// Ventas
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderPendingRepository, OrderPendingRepository>();
// Personal de Ventas
builder.Services.AddScoped<ISalesPersonsRepository, SalesPersonsRepository>();

// Series de documentos
builder.Services.AddScoped<IDocumentSeriesRepository, DocumentSeriesRepository>();

// Agrega el servicio CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", builder =>
    {
        builder.AllowAnyOrigin() // URL del origen permitido
                .AllowAnyMethod() // Permite todos los métodos
                .AllowAnyHeader(); // Permite todas las cabeceras
    });
});

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

app.UseCors("MyCorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
