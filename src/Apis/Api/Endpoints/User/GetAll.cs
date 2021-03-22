using Application.Commons;
using Application.Core;
using Application.Dtos;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Endpoints.User
{
    [Authorize]
    public class GetAll : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<UserDto>>>
    {
        private readonly IUserBusinessLogic _userBusinessLogic;

        public GetAll(IUserBusinessLogic userBusinessLogic)
        {
            _userBusinessLogic = userBusinessLogic;
        }

        [HttpGet("api/users")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
        [SwaggerOperation(
         summary: "Get all user app ",
         description: "Command getall user",
         OperationId = "user.getall",
         Tags = new[] { "UserEndpoint" })]
        public override async Task<ActionResult<Response<IEnumerable<UserDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return new Response<IEnumerable<UserDto>>
            {
                Data = await this._userBusinessLogic.GetAll(),
                StatusCode = HttpContext.Response.StatusCode
            };
        }
    }
}
