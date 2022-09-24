using Lecture4;
using Moq;

namespace LiveDemoTests;

public class StatisticsServiceTests
{
    private const int Perception = 10;
    
    [Fact]
    public void StatisticsService_CalculateMedianValue_EmptyData()
    {
        // Arrange 
        var data = new List<double>();
        var mock = new Mock<IDataStorage<double>>();
        mock.Setup(x => x.GetAllData()).Returns(data);
        var service = new StatisticsService(mock.Object);

        // Act & Assert
        Assert.Throws<Exception>(() => service.CalculateMedianValue());
    }

    [Theory]
    [InlineData(new double[] { 42 }, 42)]
    [InlineData(new double[] { 3, 2, 1 }, 2)]
    [InlineData(new double[] { 3, 2, 4, 1 }, 2.5)]
    public void StatisticsService_CalculateMedianValue(double[] data, double expected)
    {
        // Arrange 
        var mock = new Mock<IDataStorage<double>>();
        mock.Setup(x => x.GetAllData()).Returns(data.ToList());
        var service = new StatisticsService(mock.Object);
        
        // Act 
        var result = service.CalculateMedianValue();
        
        // Assert
        Assert.Equal(expected, result, Perception);
    }
    
    [Fact]
    public void StatisticsService_AddNewStatisticsValue_CorrectSave()
    {
        // Arrange 
        var dataToSave = Random.Shared.NextDouble();
        var mock = new Mock<IDataStorage<double>>();
        mock.Setup(x => x.AddData(dataToSave)).Verifiable();
        var service = new StatisticsService(mock.Object);

        // Act
        service.AddNewStatisticsValue(dataToSave);
        
        // Assert
        mock.Verify(x => x.AddData(dataToSave));
    }
}