using RPG.Infrastructure;

namespace RPG.API.Public
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Add services to the container.
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddInfrastructureServices(builder.Configuration);

            // Configure the HTTP request pipeline.
            WebApplication app = builder.Build();
            if (app.Environment.IsDevelopment()) app.UseSwagger();
            if (app.Environment.IsDevelopment()) app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}