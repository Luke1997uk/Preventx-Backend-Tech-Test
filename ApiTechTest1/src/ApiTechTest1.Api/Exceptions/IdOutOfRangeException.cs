namespace ApiTechTest1.Api.Exceptions
{
    using System;

    /// <summary>
    /// Exception for invalid Ids.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class IdOutOfRangeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdOutOfRangeException"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public IdOutOfRangeException(int id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public int Id { get; init; }
    }
}
