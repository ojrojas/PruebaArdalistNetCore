using Application.Commons;
using Application.Core;
using Application.Dtos;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Endpoints.User
{
    /// <summary>
    /// Delete endpoint users
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    [Authorize]
    public class Delete : BaseAsyncEndpoint.WithRequest<UserDto>.WithResponse<Response<UserDto>>
    {
        /// <summary>
        /// Property user business logic
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        private readonly IUserBusinessLogic _userBusinessLogic;

        /// <summary>
        /// Constructor delete user business logic 
        /// </summary>
        /// <author>Oscar Julian Rojas </author>
        /// <date>21/03/20201</date>
        /// <param name="userBusinessLogic">property user business logic</param>
        public Delete(IUserBusinessLogic userBusinessLogic)
        {
            _userBusinessLogic = userBusinessLogic;
        }

        /// <summary>
        /// Delete business logic
        /// </summary>
        /// <param name="request">Request entity user</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>User created</returns>
        [HttpDelete("api/users")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
        [SwaggerOperation(
         summary: "Delete user app ",
         description: "Command delete user",
         OperationId = "user.delete",
         Tags = new[] { "UserEndpoint" })]
        public override async Task<ActionResult<Response<UserDto>>> HandleAsync(UserDto request, CancellationToken cancellationToken = default)
        {
            return new Response<UserDto>
            {
                Data = await this._userBusinessLogic.Delete(request),
                StatusCode = HttpContext.Response.StatusCode
            };
        }
    }
}
