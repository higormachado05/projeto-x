using PJ_API.Application.Handlers;
using PJ_API.Domain.Repositories;
using PJ_API.Application.Queries;
using PJ_API.Domain.Entities;
using Moq;
using Xunit;
using System.Collections.Generic;

namespace PJ_API.Tests
{
    public class GetAllPersonsQueryHandlerTests
    {
        [Fact]
        public void Handle_ReturnsAllPersons()
        {
            // Arrange
            var mockRepo = new Mock<IPersonRepository>();
            var persons = new List<Person>
            {
                new Person { Id = 1, Name = "Alice" },
                new Person { Id = 2, Name = "Bob" }
            };
            mockRepo.Setup(r => r.GetAll()).Returns(persons);
            var handler = new GetAllPersonsQueryHandler(mockRepo.Object);
            var query = new GetAllPersonsQuery();

            // Act
            var result = handler.Handle(query);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Persons.Count);
            Assert.Equal("Alice", result.Persons[0].Name);
            Assert.Equal("Bob", result.Persons[1].Name);
        }
    }
}
