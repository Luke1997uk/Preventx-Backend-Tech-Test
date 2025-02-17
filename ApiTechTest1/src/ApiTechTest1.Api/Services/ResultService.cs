namespace ApiTechTest1.Api.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using ApiTechTest1.Infrastructure.Objects;
    using ApiTechTest1.Infrastructure.Repositories;

    /// <summary>
    /// Service for interacting with Results.
    /// </summary>
    /// <seealso cref="ApiTechTest1.Api.Services.IResultService" />
    public class ResultService : IResultService
    {
        private readonly IResultRepository _resultRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultService"/> class.
        /// </summary>
        /// <param name="resultRepository">The result repository.</param>
        public ResultService(IResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }

        /// <summary>
        /// Gets the result asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<Result> GetResultAsync(int id, CancellationToken cancellationToken)
        {
            var results = await _resultRepository.GetAsync();

            return results.FirstOrDefault();
        }

        /// <summary>
        /// Lists the Result asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<IEnumerable<Result>> ListResultsAsync(ListResultsRequest request, CancellationToken cancellationToken)
        {
            return await _resultRepository.GetAsync();
        }
    }
}
