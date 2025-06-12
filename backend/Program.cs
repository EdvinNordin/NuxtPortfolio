var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNuxtApp",
        policy => policy.WithOrigins("http://localhost:3000") // Nuxt dev server
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // ...other dev-only code...
}

app.UseHttpsRedirection();

app.UseCors("AllowNuxtApp");

app.MapControllers(); // <-- This now works

app.Run();
