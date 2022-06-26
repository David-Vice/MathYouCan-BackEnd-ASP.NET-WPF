using ActAPI.Data;
using ActAPI.Services;
using ActAPI.Services.Abstract;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
   options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<DbConnectionInfo>(settings => builder.Configuration.GetSection("ConnectionStrings").Bind(settings));
builder.Services.AddScoped<IDataContext, DataContext>();
builder.Services.AddScoped<IOfflineExamService,OfflineExamService>();
builder.Services.AddScoped<ISectionService, SectionService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IQuestionAnswerService, QuestionAnswerService>();
builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy", builder =>
     {
         builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
     });
});
builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseStaticFiles();
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider=new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),@"Uploads")),
//    RequestPath=new PathString("/Uploads")
//});;
app.UseAuthorization();

app.MapControllers();

app.Run();
