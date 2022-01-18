using System;
using System.Net;
using System.Threading.Tasks;
using Auction.Business.Exceptions;
using Auction.Business.Services.Logging;
using Auction.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auction.CustomExceptionMiddleware
{
    public class ExceptionMiddleware : Controller
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _logger;
        public ExceptionMiddleware(RequestDelegate next, ILoggerService logger)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogError($"Entity not found exception from the custom middleware: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (ArgumentNullException ex)
            {
                _logger.LogError($"Invalid argument passed: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (AccessViolationException ex)
            {
                _logger.LogError($"Access violation error from the custom middleware: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception switch
            {
                EntityNotFoundException => (int)HttpStatusCode.NotFound,
                ArgumentNullException => (int)HttpStatusCode.BadRequest,
                AccessViolationException => (int)HttpStatusCode.Forbidden,
                _ => (int)HttpStatusCode.InternalServerError,
            }; ;

            var message = exception switch
            {
                EntityNotFoundException => exception.Message,
                AccessViolationException => exception.Message,
                _ => "Internal Server Error."
            };

            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = message,
            }.ToString());
        }
    }
}
