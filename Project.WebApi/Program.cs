using Project.Bll.DependencyResolvers;
using Project.WebApi.DependencyResolvers;
using Project.WebApi.MapperResolver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextService(); // context class ın middleware eklenmesi
builder.Services.AddRepositoryService(); // repository servisinin middleware e eklenmesi
builder.Services.AddManagerService();
builder.Services.AddAutoMapperService();
builder.Services.AddVmMapperService();
builder.Services.AddFluentValidationService();

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
