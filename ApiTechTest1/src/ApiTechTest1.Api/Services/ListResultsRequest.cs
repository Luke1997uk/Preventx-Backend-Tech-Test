using System;
using System.Collections.Generic;
using System.Linq;
using ApiTechTest1.Infrastructure.Objects;

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

        /// <summary>
        /// Gets the order Direction by.
        /// </summary>
        public string OrderDirection { get; init; }

        /// <summary>
        /// Gets the Filter by String names and the value to filter by.
        /// </summary>
        public Dictionary<string, int?> FilterLevels { get; init; } = new();

        /// <summary>
        /// Apply selected sorting by.
        /// </summary>
        public IEnumerable<Result> ApplySorting(IEnumerable<Result> results)
        {
            if (string.IsNullOrWhiteSpace(OrderBy))
            {
                return results;
            }

            if (!string.IsNullOrWhiteSpace(OrderDirection) &&
                !OrderDirection.Equals("asc", StringComparison.OrdinalIgnoreCase) &&
                !OrderDirection.Equals("desc", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("OrderDirection must be either 'asc' or 'desc'.");
            }

            bool descending = OrderDirection?.Equals("desc", StringComparison.OrdinalIgnoreCase) == true;

            Func<Result, object> keySelector;

            switch (OrderBy.ToLower(System.Globalization.CultureInfo.CurrentCulture))
            {
                case "chlamydia":
                    keySelector = r => r.ChlamydiaResultsLevel;
                    break;
                case "gonorrhea":
                    keySelector = r => r.GonorrheaResultsLevel;
                    break;
                default:
                    return results;
            }

            if (keySelector == null)
            {
                return results;
            }

            return descending ? results.OrderByDescending(keySelector) : results.OrderBy(keySelector);
        }

        /// <summary>
        /// Apply Selected Level Filtering.
        /// </summary>
        public IEnumerable<Result> ApplyLevelFilter(IEnumerable<Result> results)
        {
            foreach (var filter in FilterLevels)
            {
                if (!filter.Value.HasValue)
                {
                    continue;
                }

                var filterKey = filter.Key.ToLower(System.Globalization.CultureInfo.CurrentCulture);
                double filterValue = filter.Value.Value;

                switch (filterKey)
                {
                    case "chlamydia":
                        results = results.Where(r => r.ChlamydiaResultsLevel > filterValue);
                        break;
                    case "gonorrhea":
                        results = results.Where(r => r.GonorrheaResultsLevel > filterValue);
                        break;
                    default:
                        throw new ArgumentException($"Invalid filter key: {filter.Key}");
                }
            }

            return results;
        }
    }
}
