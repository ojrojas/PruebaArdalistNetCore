using Application.Commons;
using Application.Commons.Constants;
using Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace Application.Api.Extensions
{
    /// <summary>
    /// Errormiddleware manager error application
    /// </summary>
    /// <auhtor>Oscar Julian Rojas</auhtor>
    /// <date>20/03/2021</date>
    public class ErrorMiddlewareExtensions
    {
        /// <summary>
        /// Delegate request context aplication api
        /// </summary>
        public readonly RequestDelegate _requestDeletegate;
        /// <summary>
        /// Logger information
        /// </summary>
        private readonly ILogger<ErrorMiddlewareExtensions> _logger;

        /// <summary>
        /// Contructors request delegate revision
        /// </summary>
        /// <param name="requestDeletegate">request delegate </param>
        /// <param name="logger">log information</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/03/2021</date>
        public ErrorMiddlewareExtensions(RequestDelegate requestDeletegate, ILogger<ErrorMiddlewareExtensions> logger)
        {
            _requestDeletegate = requestDeletegate;
            _logger = logger;
        }

        /// <summary>
        /// Invoke action controller context api
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDeletegate(context);
            }
            catch (Exception exception)
            {
                await ErrorResult(exception, context);
            }
        }

        /// <summary>
        /// Error result exception
        /// </summary>
        /// <param name="exception">Exception result</param>
        /// <param name="context">Context application</param>
        /// <returns>Void</returns>
        /// <auhtor>Oscar Julian Rojas</auhtor>
        /// <date>20/03/2021</date>
        public async Task ErrorResult(Exception exception, HttpContext context)
        {
            context.Response.StatusCode = (int)GetErrorCode(exception);
            context.Response.ContentType = ApisConstants.ContentType;
          
            var errorResponse = new ErrorResponseDto
            {
                ErrorCode = context.Response.StatusCode,
                Message = exception.Message,
                ErrorType = exception.GetType().Name,
                Source = exception.Source,
                ActionName = (string)context.GetRouteData()?.Values[ApisConstants.ActionName],
                ControllerName = (string)context.GetRouteData()?.Values[ApisConstants.ControllerName],
                UserId = context.User.HasClaim(x => x.Value.Equals("Id")) ? context.User.FindFirst("Id").Value : string.Empty
            };
            _logger.LogInformation("Error application");
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new Response<ErrorResponseDto> { 
                Data = errorResponse,
                StatusCode = errorResponse.ErrorCode,
                Success = errorResponse.ErrorCode != default ? false : true,
                Message = errorResponse.Message
            }));
        }

        /// <summary>
        /// Geterror code 
        /// </summary>
        /// <param name="e">exception result</param>
        /// <returns>Status code application</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/03/2021</date>
        private static HttpStatusCode GetErrorCode(Exception e)
        {
            return e switch
            {
                ValidationException _ => HttpStatusCode.BadRequest,
                FormatException _ => HttpStatusCode.BadRequest,
                AuthenticationException _ => HttpStatusCode.Forbidden,
                NotImplementedException _ => HttpStatusCode.NotImplemented,
                AccessViolationException _ => HttpStatusCode.Unauthorized,
                _ => HttpStatusCode.InternalServerError,
            };
        }
    }
}
