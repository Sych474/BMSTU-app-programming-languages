namespace Lecture4;

public interface IDataStorage<T>
{
    List<T> GetAllData();

    void AddData(T data);
}

public class FileDataStorage : IDataStorage<double>
{
    private const string DataFilename = "AppData.txt";
    
    public List<double> GetAllData()
    {
        var lines = File.ReadLines(DataFilename).ToList();

        var data = new List<double>(lines.Count);
        foreach (var line in lines)
            data.Add(double.Parse(line));

        return data;
    }

    public void AddData(double data)
    {
        File.AppendAllLines(DataFilename, new []{ data.ToString() });
    }
}