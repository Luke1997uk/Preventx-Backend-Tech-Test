namespace ApiTechTest1.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ApiTechTest1.Infrastructure.Objects;

    /// <summary>
    /// Interface for accessing result data.
    /// </summary>
    public interface IResultRepository
    {
        /// <summary>
        /// Gets all results.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Result>> GetAsync();
    }
}
