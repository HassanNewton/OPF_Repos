var builder = WebApplication.CreateBuilder(args);

// Add Swagger services for API testing (development only)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Enable Swagger middleware only in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Map controllers (API endpoints)
app.MapControllers();

app.Run();