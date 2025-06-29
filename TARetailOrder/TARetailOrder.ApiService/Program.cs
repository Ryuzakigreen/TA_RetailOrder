

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TARetailOrder.ApiService.DataContext;
using TARetailOrder.ApiService.Repositories.Customers;
using TARetailOrder.ApiService.Services.Customer;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", false);

//For Aspire's postgrest db server
builder.AddNpgsqlDbContext<DBDataContext>("RetailOrderDB");

//Initiating DBContext configuration on separate db server - for instance my local server
//builder.Services.AddDbContext<DBDataContext>(options =>
//    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<ICustomersAppService, CustomersAppService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Retail Order API",
        Version = "v1",
        Description = "API for managing retail orders and customers"
    });
});


var app = builder.Build();
app.MapDefaultEndpoints();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Retail Order API V1");
        c.RoutePrefix = string.Empty; 
    });
}

// Configure the HTTP request pipeline.
app.UseExceptionHandler();
app.UseRouting();
app.MapControllers();
app.CreateDbIfNotExists();

app.Run();

