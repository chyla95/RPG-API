using System.Text.Json.Serialization;
using RPG.Infrastructure;

namespace RPG.API.Staff
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // AddEntity services to the container.
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddInfrastructureServices(builder.Configuration);

            builder.Services.AddMvc()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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