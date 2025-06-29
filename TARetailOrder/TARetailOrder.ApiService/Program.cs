

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TARetailOrder.ApiService.DataContext;
using TARetailOrder.ApiService.Repositories.Categories;
using TARetailOrder.ApiService.Repositories.Customers;
using TARetailOrder.ApiService.Services;
using TARetailOrder.ApiService.Services.Categories;
using TARetailOrder.ApiService.Services.Customers;

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

builder.Services.AddAutoMapper(config =>
{
    DtoMapper.CreateMappings(config);
});

builder.Services.AddEndpointsApiExplorer();

//Customer
builder.Services.AddScoped<ICustomersAppService, CustomersAppService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
//Category
builder.Services.AddScoped<ICategoriesAppService, CategoriesAppService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();




builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.FullName);
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

