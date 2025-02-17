namespace ApiTechTest1.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ApiTechTest1.Infrastructure.Objects;

    /// <summary>
    /// Dummy access for result data - DO NOT CHANGE.
    /// </summary>
    /// <seealso cref="ApiTechTest1.Infrastructure.Repositories.IResultRepository" />
    public class ResultRepository : IResultRepository
    {
        /// <summary>
        /// Gets all results asynchronous.
        /// </summary>
        /// <returns></returns>
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<IEnumerable<Result>> GetAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            return
            [
                new(1, "John Coleson", 11, 15),
                new(2, "Jane Roberts", 20, 40),
                new(3, "Coleen Johns", 15, 35),
                new(4, "Robert Smithson", 4, 6),
            ];
        }
    }
}
