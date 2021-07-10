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
    /// <summary>
    /// Getall endpoint users
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    [Authorize]
    public class GetAll : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<UserDto>>>
    {
        /// <summary>
        /// Property user business logic
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        private readonly IUserBusinessLogic _userBusinessLogic;

        /// <summary>
        /// Constructor getall user business logic 
        /// </summary>
        /// <author>Oscar Julian Rojas </author>
        /// <date>21/03/20201</date>
        /// <param name="userBusinessLogic">property user business logic</param>
        public GetAll(IUserBusinessLogic userBusinessLogic)
        {
            _userBusinessLogic = userBusinessLogic;
        }


        /// <summary>
        /// getall business logic
        /// </summary>
        /// <param name="request">Request entity user</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>IEnumerable users</returns>
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
            return await this._userBusinessLogic.GetAll();
        }
    }
}
