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
    /// Update password endpoint users
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    [Authorize]
    public class UpdatePassword : BaseAsyncEndpoint.WithRequest<UserDto>.WithResponse<Response<UserDto>>
    {
        /// <summary>
        /// Property user business logic
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        private readonly IUserBusinessLogic _userBusinessLogic;

        /// <summary>
        /// Constructor update password user business logic 
        /// </summary>
        /// <author>Oscar Julian Rojas </author>
        /// <date>21/03/20201</date>
        /// <param name="userBusinessLogic">property user business logic</param>
        public UpdatePassword(IUserBusinessLogic userBusinessLogic)
        {
            _userBusinessLogic = userBusinessLogic;
        }


        /// <summary>
        /// update password business logic
        /// </summary>
        /// <param name="request">Request entity user</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>User created</returns>
        [HttpPatch("api/users/updatepassword")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
        [SwaggerOperation(
         summary: "Update user app ",
         description: "Command update user",
         OperationId = "user.update",
         Tags = new[] { "UserEndpoint" })]
        public override async Task<ActionResult<Response<UserDto>>> HandleAsync(UserDto request, CancellationToken cancellationToken = default)
        {
            return new Response<UserDto>
            {
                Data = await this._userBusinessLogic.Update(request),
                StatusCode = HttpContext.Response.StatusCode
            };
        }
    }
}
