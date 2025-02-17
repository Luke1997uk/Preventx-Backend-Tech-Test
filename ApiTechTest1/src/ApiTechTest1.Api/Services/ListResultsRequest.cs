namespace ApiTechTest1.Api.Services
{
    /// <summary>
    /// Request object for ListResults.
    /// </summary>
    public class ListResultsRequest
    {
        /// <summary>
        /// Gets the search string.
        /// </summary>
        public string SearchString { get; init; }

        /// <summary>
        /// Gets the order by.
        /// </summary>
        public string OrderBy { get; init; }
    }
}
