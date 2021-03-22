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

namespace Api.Endpoints.TypeIdentification
{
    [Authorize]
    public class GetAll : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<TypeIdentificationDto>>>
    {
        private readonly IIdentificationTypeBusinessLogic _identificationTypeBusinessLogic;

        public GetAll(IIdentificationTypeBusinessLogic identificationTypeBusinessLogic)
        {
            _identificationTypeBusinessLogic = identificationTypeBusinessLogic;
        }

        [HttpGet("api/typeidentifications")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
        [SwaggerOperation(
         summary: "Get all typeidentifications app ",
         description: "Command getall user",
         OperationId = "typeidentification.getall",
         Tags = new[] { "TypeIdentificationEndpoints" })]
        public override async Task<ActionResult<Response<IEnumerable<TypeIdentificationDto>>>> HandleAsync(CancellationToken cancellationToken = default)
        {
            return new Response<IEnumerable<TypeIdentificationDto>>
            {
                Data = await this._identificationTypeBusinessLogic.GetAll(),
                StatusCode = HttpContext.Response.StatusCode
            };
        }
    }
}
