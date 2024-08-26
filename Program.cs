using Microsoft.EntityFrameworkCore;
using RandomTgAPI.DBContexts;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.SetBasePath(@"D:\VisualStudioCSharp\RandomTgAPI").AddJsonFile("appsettings.json");

        // Add services to the container.
        builder.Services.AddControllers();

        // Configure DbContext with the connection string
        builder.Services.AddDbContext<UserContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
