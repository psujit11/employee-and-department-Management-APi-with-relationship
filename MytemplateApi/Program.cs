using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MytemplateApi.Data;
using MytemplateApi.DTOs;
using MytemplateApi.Mapping;
using MytemplateApi.Models;
using MytemplateApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IGenericCrudService<Department, CreateDepartmentDto, GetDepartmentDto>, DepartmentService>();
builder.Services.AddScoped<IGenericCrudService<Employee, CreateEmployeeDto, GetEmployeeDto>, EmployeeService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/departments", async (IGenericCrudService<Department, CreateDepartmentDto, GetDepartmentDto> service) =>
{
    return await service.GetAllAsync();
});

app.MapGet("/departments/{id}", async (int id, IGenericCrudService<Department, CreateDepartmentDto, GetDepartmentDto> service) =>
{
    return await service.GetByIdAsync(id);
});

app.MapPost("/departments", async (CreateDepartmentDto createDto, IGenericCrudService<Department, CreateDepartmentDto, GetDepartmentDto> service) =>
{
    return await service.AddAsync(createDto);
});

app.MapPut("/departments/{id}", async (int id, CreateDepartmentDto updateDto, IGenericCrudService<Department, CreateDepartmentDto, GetDepartmentDto> service) =>
{
    return await service.UpdateAsync(id, updateDto);
});

app.MapDelete("/departments/{id}", async (int id, IGenericCrudService<Department, CreateDepartmentDto, GetDepartmentDto> service) =>
{
    await service.DeleteAsync(id);
    return Results.Ok();
});

// Map the EmployeeService endpoints
app.MapGet("/employees", async (IGenericCrudService<Employee, CreateEmployeeDto, GetEmployeeDto> service) =>
{
    return await service.GetAllAsync();
});

app.MapGet("/employees/{id}", async (int id, IGenericCrudService<Employee, CreateEmployeeDto, GetEmployeeDto> service) =>
{
    return await service.GetByIdAsync(id);
});

app.MapPost("/employees", async (CreateEmployeeDto createDto, IGenericCrudService<Employee, CreateEmployeeDto, GetEmployeeDto> service) =>
{
    return await service.AddAsync(createDto);
});

app.MapPut("/employees/{id}", async (int id, CreateEmployeeDto updateDto, IGenericCrudService<Employee, CreateEmployeeDto, GetEmployeeDto> service) =>
{
    return await service.UpdateAsync(id, updateDto);
});

app.MapDelete("/employees/{id}", async (int id, IGenericCrudService<Employee, CreateEmployeeDto, GetEmployeeDto> service) =>
{
    await service.DeleteAsync(id);
    return Results.Ok();
});

app.Run();


