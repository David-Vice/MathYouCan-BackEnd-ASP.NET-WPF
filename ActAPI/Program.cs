using ActAPI.Data;
using ActAPI.Services;
using ActAPI.Services.Abstract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<DbConnectionInfo>(settings => builder.Configuration.GetSection("ConnectionStrings").Bind(settings));
builder.Services.AddScoped<IDataContext, DataContext>();
builder.Services.AddScoped<IOfflineExamService,OfflineExamService>();
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
