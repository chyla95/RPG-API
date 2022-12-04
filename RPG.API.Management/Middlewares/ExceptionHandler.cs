﻿
using AutoMapper;
using RPG.Domain.Dtos;
using RPG.Domain.Exceptions;

namespace RPG.API.Management.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandler> _logger;
        private readonly IMapper _mapper;

        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger, IMapper mapper)
        {
            _next = next;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (HttpException exception)
            {
                await HandleExceptionAsync(httpContext, exception);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, HttpException exception)
        {
            HttpExceptionDto httpExceptionDto = _mapper.Map<HttpExceptionDto>(exception);

            httpContext.Response.StatusCode = (int)exception.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(httpExceptionDto);
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            _logger.LogError(exception.ToString());

            HttpInternalServerErrorException internalServerErrorException = new(exception.Message);
            HttpExceptionDto httpExceptionDto = _mapper.Map<HttpExceptionDto>(internalServerErrorException);

            httpContext.Response.StatusCode = (int)internalServerErrorException.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(httpExceptionDto);
        }

    }
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandlerExtensions
    {
        public static IApplicationBuilder SetupExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandler>();
        }
    }
}
