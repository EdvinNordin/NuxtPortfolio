
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowFrontend",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000", "http://www.edvinnordin.me", "edvinnordin.me", "edvinnordin.netlify.app")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                      });
});

var app = builder.Build();

app.UseCors("AllowFrontend");

async Task<object> json()
{
    var json = await File.ReadAllTextAsync("projects.json");
    return JsonSerializer.Deserialize<object>(json);
}

app.MapGet("/projects", async () =>
{
    var json = await File.ReadAllTextAsync("projects.json");
    var projects = JsonSerializer.Deserialize<object>(json);
    return projects;
    //return json();
});

app.MapGet("/projects/{name}", async (string name) =>
{

    var projects = await json();
    foreach (var project in ((JsonElement)projects).EnumerateArray())
    {
        if (project.GetProperty("name").GetString() == name)
        {
            return Results.Ok(project);
        }
    }
    return Results.NotFound();
});

app.MapGet("/", () => "Welcome to the Projects API!");


app.Run();
