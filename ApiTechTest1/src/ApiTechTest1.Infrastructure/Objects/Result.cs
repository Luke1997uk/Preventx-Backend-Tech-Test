namespace ApiTechTest1.Infrastructure.Objects
{
    /// <summary>
    /// Result DTO.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        public Result()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="chlamydiaResultsLevel">The chlamydia results level.</param>
        /// <param name="gonorrheaResultsLevel">The gonorrhea results level.</param>
        public Result(int id, string name, int chlamydiaResultsLevel, int gonorrheaResultsLevel)
        {
            this.Id = id;
            this.Name = name;
            this.ChlamydiaResultsLevel = chlamydiaResultsLevel;
            this.GonorrheaResultsLevel = gonorrheaResultsLevel;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; init; }

        /// <summary>
        /// Gets the Chlamydia results level.
        /// </summary>
        public int ChlamydiaResultsLevel { get; init; }

        /// <summary>
        /// Gets the gonorrhea results level.
        /// </summary>
        public int GonorrheaResultsLevel { get; init; }
    }
}
