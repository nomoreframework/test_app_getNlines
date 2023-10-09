var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
                builder.SetIsOriginAllowed(_ => true)
                    .WithOrigins($"http://localhost")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
        });
if(builder.Environment.IsDevelopment()) {
    builder.Services.AddScoped<IDataContextStorage,DataContextStorage>();
    builder.Services.AddScoped<IPostRepository,PostRepository>();
}
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
