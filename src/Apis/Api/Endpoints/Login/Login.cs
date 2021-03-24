using Application.Commons;
using Application.Core;
using Application.Dtos;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Endpoints.Login
{
    /// <summary>
    /// Endpoint Login 
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>20/03/2021</date>
    public class Login : BaseAsyncEndpoint.WithRequest<LoginDto>.WithResponse<Response<string>>
    {
        /// <summary>
        /// Logic business user domain
        /// </summary>
        private readonly ILoginBusinessLogic _userBusinessLogic;

        /// <summary>
        /// Constructor endpoint inject user business
        /// </summary>
        /// <param name="_userBusinessLogic">instance user business</param>
        public Login(ILoginBusinessLogic userBusinessLogic)
        {
            _userBusinessLogic = userBusinessLogic;
        }


        /// <summary>
        /// Login Application 
        /// </summary>
        /// <param name="request">Login command request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response Token</returns>
        [HttpPost("api/login")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
        [SwaggerOperation(
          summary: "Login user into app",
          description: "Login to users",
          OperationId = "Login",
          Tags = new[] { "LoginEndpoint" })]
        public override async Task<ActionResult<Response<string>>> HandleAsync(LoginDto request, CancellationToken cancellationToken = default)
        {
            return new Response<string>
            {
                Data = await this._userBusinessLogic.LoginUser(request),
                StatusCode = HttpContext.Response.StatusCode
            };
        }
    }
}
