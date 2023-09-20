using Lecture4;
using Moq;

namespace Lecture4Tests;

public class StatisticsServiceTests
{
    [Fact]
    public void StatisticsService_AddNewStatisticsValue_Test()
    {
        var data = Random.Shared.NextDouble();
        var storageMock = new Mock<IDataStorage<double>>();

        storageMock.Setup(x => x.AddData(data)).Verifiable();
        
        var service = new StatisticsService(storageMock.Object);

        service.AddNewStatisticsValue(data);
        
        storageMock.Verify(x => x.AddData(data));
    }
    
    [Fact]
    public void StatisticsService_CalculateMedianValue_Odd()
    {
        // Arrange
        var data = new List<double>() { 1, 2, 4 };
        var storageMock = new Mock<IDataStorage<double>>();

        storageMock.Setup(x => x.GetAllData()).Returns(data).Verifiable();

        var service = new StatisticsService(storageMock.Object);
        
        // Act 
        var result = service.CalculateMedianValue();

        // Assert
        Assert.Equal(2, result, 10);
    }
    
    [Fact]
    public void StatisticsService_CalculateMedianValue_Even()
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

    [Theory]
    [InlineData(new double[] {1, 2, 3}, 2)]
    public void StatisticsService_CalculateMedianValue_Test(double[] data, double expectedResult)
    {
        // Arrange
        var storageMock = new Mock<IDataStorage<double>>();
        storageMock.Setup(x => x.GetAllData()).Returns(data.ToList()).Verifiable();

        var service = new StatisticsService(storageMock.Object);
        
        // Act 
        var result = service.CalculateMedianValue();

        // Assert
        Assert.Equal(expectedResult, result, 10);
    }
    
    // пустые данные
    // один элемент
    // четное число элементов
    // нечетное число элементов
    // несортированный массив 
}