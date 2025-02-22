namespace ApiTechTest1.Api.UnitTests.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using ApiTechTest1.Api.Exceptions;
    using ApiTechTest1.Api.Services;
    using ApiTechTest1.Infrastructure.Objects;
    using ApiTechTest1.Infrastructure.Repositories;

    using FluentAssertions;

    using Moq;

    using Xunit;

    /// <summary>
    /// Unit testing for <see cref="ResultService"/>.
    /// </summary>
    public class ResultServiceShould
    {
        private readonly Mock<IResultRepository> _resultRepositoryMock;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultServiceShould"/> class.
        /// </summary>
        public ResultServiceShould()
        {
            _resultRepositoryMock = new Mock<IResultRepository>(MockBehavior.Strict);
        }

        /// <summary>
        /// Unit tests success for <see cref="ResultService.GetResultAsync"/>.
        /// </summary>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public async Task GetResultAsyncShould(int id)
        {
            // Arrange
            var cancellationToken = CancellationToken.None;

            _resultRepositoryMock.Setup(x => x.GetAsync()).ReturnsAsync(GetResults());

            var testObject = GetResultService();

            // Act
            var result = await testObject.GetResultAsync(id, cancellationToken);

            // Assert
            result.Id.Should().Be(id);
            result.Name.Should().NotBeNullOrWhiteSpace();
            result.ChlamydiaResultsLevel.Should().NotBe(0);
            result.ChlamydiaResultsLevel.Should().NotBe(0);
        }

        /// <summary>
        /// Unit tests Id request object is out of range for <see cref="ResultService.GetResultAsync"/>.
        /// </summary>
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-999)]
        public async Task GetResultAsyncShould_ThrowIdOutOfRangeException(int id)
        {
            // Arrange
            var cancellationToken = CancellationToken.None;

            var expectedResult = new Result { Id = id };

            var testObject = GetResultService();

            // Act
            var exception = await Assert.ThrowsAsync<IdOutOfRangeException>(() => testObject.GetResultAsync(id, cancellationToken));

            // Assert
            Assert.Equal(id, exception.Id);
            Assert.Equal($"Number out of range: {id}", exception.Message);
        }

        private static IEnumerable<Result> GetResults()
        {
            return new List<Result>
            {
                new(1, "John Coleson", 11, 15),
                new(2, "Jane Roberts", 20, 40),
                new(3, "Coleen Johns", 15, 35),
                new(4, "Robert Smithson", 4, 6),
            };
        }

        private ResultService GetResultService()
        {
            return new ResultService(_resultRepositoryMock.Object);
        }
    }
}
