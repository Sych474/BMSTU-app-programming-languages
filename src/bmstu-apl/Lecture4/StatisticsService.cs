namespace Lecture4;

public class StatisticsService
{
    private readonly IDataStorage<double> _dataDataStorage;

    public StatisticsService(IDataStorage<double> dataDataStorage)
    {
        _dataDataStorage = dataDataStorage;
    }

    public double CalculateMedianValue()
    {
        var data = _dataDataStorage.GetAllData();
        
        data.Sort();
        var middleIndex = data.Count / 2;
        if (data.Count % 2 == 1)
            return data[middleIndex];
        else 
            return (data[middleIndex - 1] + data[middleIndex]) / 2;
    }

    public void AddNewStatisticsValue(double newValue)
    {
        _dataDataStorage.AddData(newValue);
    }
}