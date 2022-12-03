using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RPG.Infrastructure;
using Swashbuckle.AspNetCore.Filters;

namespace RPG.API.Staff
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // AddEntity services to the container.
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                string? JwtTokenSecret = builder.Configuration.GetSection("AppSettings:JwtTokenSecret").Value;
                if (JwtTokenSecret == null) throw new Exception("AppSettings:JwtToken is not defined!");

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(JwtTokenSecret)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            builder.Services.AddSwaggerGen(configuration =>
            {
                configuration.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the bearer scheme, e.g. \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                configuration.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddInfrastructureServices(builder.Configuration);

            //builder.Services.AddMvc()
            //    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            // Configure the HTTP request pipeline.
            WebApplication app = builder.Build();
            if (app.Environment.IsDevelopment()) app.UseSwagger();
            if (app.Environment.IsDevelopment()) app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}