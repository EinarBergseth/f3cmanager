using Xunit;
using DataAccess.Models;

namespace DataAccess.Tests
{
    public class EventTests
    {
        [Fact]
        public void EndTime_Throws_IfBeforeStartTime()
        {
            // Arrange
            var sut = new Event();
            sut.StartTime = new DateTime(2023, 1, 1);
            
            // Act & Assert
            Assert.Throws<ArgumentException>(() => sut.EndTime = new DateTime(2022, 1, 1));
        }

        [Fact]
        public void RegistrationEndTime_Throws_IfBeforeRegistrationStartTime()
        {
            // Arrange
            var sut = new Event();
            sut.RegistrationStartTime = new DateTime(2023, 1, 1);
            
            // Act & Assert
            Assert.Throws<ArgumentException>(() => sut.RegistrationEndTime = new DateTime(2022, 1, 1)); 
        }

        [Fact]
        public void DefaultValues()
        {
            // Arrange & Act
            var sut = new Event();
            
            // Assert
            Assert.Equal("", sut.Name);
            Assert.False(sut.IsOpenForRegistration);
        }
    }
}