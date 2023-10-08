var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddCors(options =>
//         {
//             options.AddDefaultPolicy(builder =>
//                 builder.SetIsOriginAllowed(_ => true)
//                     .WithOrigins($"http://localhost")
//                     .AllowAnyMethod()
//                     .AllowAnyHeader()
//                     .AllowCredentials());
//         });
if(builder.Environment.IsDevelopment()) 
    builder.Services.AddSingleton<IPostRepository,PostRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
