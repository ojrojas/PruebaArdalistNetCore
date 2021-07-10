using Application.Commons;
using Application.Core;
using Application.Dtos;
using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Endpoints.TypeIDentification
{
    /// <summary>
    /// Create endpoint users
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    [Authorize]
    public class Create : BaseAsyncEndpoint.WithRequest<TypeIdentificationDto>.WithResponse<Response<TypeIdentificationDto>>
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
        public Create(IIdentificationTypeBusinessLogic identificationTypeBusinessLogic)
        {
            _identificationTypeBusinessLogic = identificationTypeBusinessLogic;
        }

        /// <summary>
        /// Create business logic
        /// </summary>
        /// <param name="request">Request entity user</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>User created</returns>
        [HttpPost("api/typeidentifications")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(Response<string>), StatusCodes.Status200OK)]
        [SwaggerOperation(
         summary: "Create tipe identifications app ",
         description: "Command create type identification",
         OperationId = "typeidentification.create",
         Tags = new[] { "TypeIdentificationEndpoints" })]
        public override async Task<ActionResult<Response<TypeIdentificationDto>>> HandleAsync(TypeIdentificationDto request, CancellationToken cancellationToken = default)
        {
            return await _identificationTypeBusinessLogic.CreateTypeIdentification(request);
        }
    }
}
