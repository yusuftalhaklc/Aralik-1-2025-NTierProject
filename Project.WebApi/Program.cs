using FluentValidation;
using FluentValidation.AspNetCore;
using Project.Bll.DependencyResolvers;
using Project.WebApi.MapperResolver;
using Project.WebApi.Validators.RequestModels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

// Hepsini entegre etmemize gerek yokmuş çünkü aynı assembly'deki tüm IValidator implementasyonlarını buluyor.
builder.Services.AddValidatorsFromAssemblyContaining<CreateCategoryRequestModelValidator>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextService(); // context class ın middleware eklenmesi
builder.Services.AddRepositoryService(); // repository servisinin middleware e eklenmesi
builder.Services.AddManagerService();
builder.Services.AddAutoMapperService();
builder.Services.AddVmMapperService();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
