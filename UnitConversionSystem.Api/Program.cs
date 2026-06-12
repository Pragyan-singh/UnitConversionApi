using UnitConversionSystem.Core.Interfaces;
using UnitConversionSystem.Core.Services;


var builder = WebApplication.CreateBuilder(args);

// Configures controllers to accept and display human-readable text strings for Enums
builder.Services.AddControllers()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- REGISTER UNIT CONVERSION SERVICES ---
// Register individual concrete strategies
builder.Services.AddScoped<IConversionStrategy, LengthConversionStrategy>();
builder.Services.AddScoped<IConversionStrategy, WeightConversionStrategy>();
builder.Services.AddScoped<IConversionStrategy, TemperatureConversionStrategy>();

// Register the main coordinator engine
builder.Services.AddScoped<ConversionEngine>();
// ----------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();