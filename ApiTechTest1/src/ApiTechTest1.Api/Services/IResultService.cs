namespace ApiTechTest1.Api.Services
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using ApiTechTest1.Infrastructure.Objects;

    /// <summary>
    /// Interface for interacting with Results.
    /// </summary>
    public interface IResultService
    {
        /// <summary>
        /// Gets the Result asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<Result> GetResultAsync(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Lists the Result asynchronous.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<IEnumerable<Result>> ListResultsAsync(ListResultsRequest request, CancellationToken cancellationToken);
    }
}
