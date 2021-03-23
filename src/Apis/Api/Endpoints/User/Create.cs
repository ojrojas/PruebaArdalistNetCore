using Application.Commons;
using Application.Core;
using Application.Dtos;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Endpoints.User
{
    /// <summary>
    /// Create endpoint users
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    [Authorize]
    public class Create : BaseAsyncEndpoint.WithRequest<UserDto>.WithResponse<Response<UserDto>>
    {
        /// <summary>
        /// Property user business logic
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        private readonly IUserBusinessLogic _userBusinessLogic;

        /// <summary>
        /// Constructor Create user business logic 
        /// </summary>
        /// <author>Oscar Julian Rojas </author>
        /// <date>21/03/20201</date>
        /// <param name="userBusinessLogic">property user business logic</param>
        public Create(IUserBusinessLogic userBusinessLogic)
        {
            _userBusinessLogic = userBusinessLogic;
        }

        /// <summary>
        /// Create business logic
        /// </summary>
        /// <param name="request">Request entity user</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>User created</returns>
        [HttpPost("api/users")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
        [SwaggerOperation(
         summary: "Create user app ",
         description: "Command create user",
         OperationId = "user.create",
         Tags = new[] { "UserEndpoint" })]
        public override async Task<ActionResult<Response<UserDto>>> HandleAsync(UserDto request, CancellationToken cancellationToken = default)
        {
            return new Response<UserDto>
            {
                Data = await this._userBusinessLogic.CreateUser(request),
                StatusCode = HttpContext.Response.StatusCode
            };
        }
    }
}
