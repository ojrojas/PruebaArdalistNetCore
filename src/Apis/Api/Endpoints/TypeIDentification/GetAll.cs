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
    /// <summary>
    /// Endpoint getall type identifications
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>21/03/2021</date>
    [Authorize]
    public class GetAll : BaseAsyncEndpoint.WithoutRequest.WithResponse<Response<IEnumerable<TypeIdentificationDto>>>
    {
        /// <summary>
        /// property type identification business logic
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>21/03/2021</date>
        private readonly IIdentificationTypeBusinessLogic _identificationTypeBusinessLogic;

        /// <summary>
        /// Constructor injection business logic type identification
        /// </summary>
        /// <param name="identificationTypeBusinessLogic">property typeidentification</param>
        public GetAll(IIdentificationTypeBusinessLogic identificationTypeBusinessLogic)
        {
            _identificationTypeBusinessLogic = identificationTypeBusinessLogic;
        }

        /// <summary>
        /// Getall endpoint
        /// </summary>
        /// <param name="cancellationToken">Cancelation</param>
        /// <returns>IEnumerable type identifications</returns>
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
            return await this._identificationTypeBusinessLogic.GetAll();
        }
    }
}
