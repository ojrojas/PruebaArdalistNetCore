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
    [Authorize]
    public class Update : BaseAsyncEndpoint.WithRequest<UserDto>.WithResponse<Response<UserDto>>
    {
        private readonly IUserBusinessLogic _userBusinessLogic;

        public Update(IUserBusinessLogic userBusinessLogic)
        {
            _userBusinessLogic = userBusinessLogic;
        }

        [HttpPut("api/user")]
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
