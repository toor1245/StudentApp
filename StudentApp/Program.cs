using Microsoft.Extensions.Options;
using StudentApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<StudentStoreDatabaseSettings>(
    builder.Configuration.GetSection("StudentStoreDatabase"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/students/add", async (Student student) =>
{
    var studentSettings = app.Services.GetRequiredService<IOptions<StudentStoreDatabaseSettings>>();
    var studentService = new StudentService(studentSettings);

    await studentService.CreateAsync(student);
    
    return student;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/students/findById", async (string id) =>
{
    var studentSettings = app.Services.GetRequiredService<IOptions<StudentStoreDatabaseSettings>>();
    var studentService = new StudentService(studentSettings);

    var student = await studentService.GetAsync(id);

    return student;
});

app.Run();