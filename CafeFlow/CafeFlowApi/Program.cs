using CafeFlowApi;
using CafeFlowApi.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SignalR servisini ekle
builder.Services.AddSignalR().AddJsonProtocol(); // JSON protokolünü kullan

// DatabaseConnection'ý servis olarak ekle
builder.Services.AddSingleton<DatabaseConnection>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);


// CORS ayarlarý (Windows Forms istemcisi için)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowClient", builder =>
    {
        builder.WithOrigins("http://cafeflow.com.tr", "https://cafeflow.com.tr") // Windows Forms'un çalýþtýðý adres
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials(); // SignalR için gerekli
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowClient"); // Politikayý "AllowAll" yerine "AllowClient" yap
app.UseAuthorization();
app.MapControllers();

// SignalR Hub için endpoint
app.MapHub<OrderHub>("/orderHub");

app.Run();