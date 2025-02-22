namespace ApiTechTest1.Api.Controllers
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using ApiTechTest1.Api.Services;
    using ApiTechTest1.Infrastructure.Objects;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Controller for getting Laboratory Results.
    /// </summary>
    [ApiController]
    [Route("Laboratory")]
    public class LaboratoryController : ControllerBase
    {
        private readonly IResultService _resultService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LaboratoryController"/> class.
        /// </summary>
        /// <param name="resultService">The result service.</param>
        public LaboratoryController(IResultService resultService)
        {
            _resultService = resultService;
        }

        /// <summary>
        /// Gets the Result asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet("/GetResult/{id}")]
        public async Task<Result> GetResultAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            return await _resultService.GetResultAsync(id, cancellationToken);
        }

        /// <summary>
        /// Lists the Results asynchronous.
        /// </summary>
        /// <param name="listResultsRequest">The list Results request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpPost("/ListResults")]
        public async Task<IEnumerable<Result>> ListResultsAsync([FromBody] ListResultsRequest listResultsRequest, CancellationToken cancellationToken)
        {
            return await _resultService.ListResultsAsync(listResultsRequest, cancellationToken);
        }
    }
}
