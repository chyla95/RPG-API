using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RPG.API.Management.Middlewares;
using RPG.API.Management.Utilities;
using RPG.API.Management.Utilities.Wrappers;
using RPG.Infrastructure;
using Swashbuckle.AspNetCore.Filters;

namespace RPG.API.Management
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // AddOne services to the container.
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                string? JwtTokenSecret = builder.Configuration.GetSection(Constants.JWT_SECRET_KEY).Value;
                if (JwtTokenSecret == null) throw new NullReferenceException(nameof(JwtTokenSecret));

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

            builder.Services.AddScoped<IHttpContextWrapper, HttpContextWrapper>();
            builder.Services.AddScoped<IAppSettings, AppSettings>();
            builder.Services.AddScoped<ICurrentUser, CurrentUser>();

            builder.Services.AddInfrastructureServices(builder.Configuration);

            // Configure the HTTP request pipeline.
            WebApplication app = builder.Build();
            if (app.Environment.IsDevelopment()) app.UseSwagger();
            if (app.Environment.IsDevelopment()) app.UseSwaggerUI();
            app.SetupExceptionHandler();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseUserHandler();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}