using CafeFlowApi;
using CafeFlowApi.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SignalR servisini ekle
builder.Services.AddSignalR();

// DatabaseConnection'� servis olarak ekle
builder.Services.AddSingleton<DatabaseConnection>();

// CORS ayarlar� (Windows Forms istemcisi i�in)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
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

// CORS'u etkinle�tir
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

// SignalR Hub i�in endpoint
app.MapHub<OrderHub>("/orderHub");

app.Run();