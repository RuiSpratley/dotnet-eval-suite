using System.Net;
using System.Net.Mail;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/weatherforecast", () => {
    var summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

app.MapPost("/api/contact", async (ContactRequest request, IConfiguration configuration) =>
{
    try
    {
        var host = configuration["Smtp:Host"] ?? "localhost";
        var port = int.Parse(configuration["Smtp:Port"] ?? "587");
        var username = configuration["Smtp:Username"] ?? "";
        var password = configuration["Smtp:Password"] ?? "";

        using var client = new SmtpClient(host, port)
        {
            Credentials = new NetworkCredential(username, password),
            EnableSsl = true
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress("noreply@mycompany.pt", "MyCompany Website"),
            Subject = $"New Contact Form Submission from {request.Name}",
            Body = $"Name: {request.Name}\nEmail: {request.Email}\n\nMessage:\n{request.Message}",
            IsBodyHtml = false
        };
        
        mailMessage.To.Add("noreply@mycompany.pt");
        mailMessage.ReplyToList.Add(new MailAddress(request.Email, request.Name));

        await client.SendMailAsync(mailMessage);

        return Results.Ok(new { success = true, message = "Thank you! Your message has been sent." });
    }
    catch (Exception ex)
    {
        return Results.Json(new { success = false, message = $"Failed to send email: {ex.Message}" }, statusCode: 500);
    }
});

app.Run();

public record ContactRequest(string Name, string Email, string Message);

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}