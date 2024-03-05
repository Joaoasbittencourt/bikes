using Microsoft.EntityFrameworkCore;
using Minio;
using Mottu.Data;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MottuDb");

builder
    .Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System
            .Text
            .Json
            .Serialization
            .ReferenceHandler
            .Preserve;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MottuDbContext>((opts) => opts.UseNpgsql(connectionString));

var minioConfig = builder.Configuration.GetRequiredSection("MinioConfig");

builder.Services.AddMinio(config =>
    config
        .WithEndpoint(minioConfig.GetValue<string>("Endpoint"))
        .WithCredentials(
            minioConfig.GetValue<string>("AccessKey"),
            minioConfig.GetValue<string>("SecretKey")
        )
);

builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
