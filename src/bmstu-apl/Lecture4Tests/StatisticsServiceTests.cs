using Lecture4;
using Moq;

namespace Lecture4Tests;

public class StatisticsServiceTests
{
    
    [Fact]
    public void CalculateMedianValueTest1()
    {
        // Arrange
        var data = new List<double>() { 1, 2, 4};
        var storageMock = new Mock<IDataStorage<double>>();

        storageMock.Setup(x => x.GetAllData()).Returns(data).Verifiable();

        var service = new StatisticsService(storageMock.Object);
        
        // Act 
        var result = service.CalculateMedianValue();

        // Assert
        Assert.Equal(2, result, 10);
    }
    
    [Fact]
    public void CalculateMedianValueTest2()
    {
        // Arrange
        var data = new List<double>() { 1, 2, 3, 4};
        var storageMock = new Mock<IDataStorage<double>>();

        storageMock.Setup(x => x.GetAllData()).Returns(data).Verifiable();

        var service = new StatisticsService(storageMock.Object);
        
        // Act 
        var result = service.CalculateMedianValue();

        // Assert
        Assert.Equal(2.5, result, 10);
    }
    
}