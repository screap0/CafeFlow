using CafeFlowApi;
using CafeFlowApi.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SignalR servisini ekle
builder.Services.AddSignalR().AddJsonProtocol(); // JSON protokol�n� kullan

// DatabaseConnection'� servis olarak ekle
builder.Services.AddSingleton<DatabaseConnection>();

// CORS ayarlar� (Windows Forms istemcisi i�in)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.WithOrigins("https://www.cafeflow.com.tr") // PHP sitenizin adresi
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials(); // SignalR i�in gerekli
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
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

// SignalR Hub i�in endpoint
app.MapHub<OrderHub>("/orderHub");

app.Run();