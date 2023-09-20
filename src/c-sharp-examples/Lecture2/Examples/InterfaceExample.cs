namespace Lecture2.Examples;

public interface IApiClient
{
    int GetFollowersCount(string userId);

    List<string> GetFollowers(string userId);

    void FollowUser(string userId, string followerId);
}

public class MockApiClient : IApiClient
{
    public int GetFollowersCount(string userId) => 42;

    public List<string> GetFollowers(string userId) => new() { "Adam", "Eva" };

    public List<string> Followed => new();
    public void FollowUser(string userId, string followerId) => Followed.Add(followerId);
}

public class FollowingService
{
    private readonly IApiClient _apiClient;

    public FollowingService(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public int FollowAndGetFollowersCount(string userId, string followerId)
    {
        _apiClient.FollowUser(userId, followerId);
        // some other app logic ... 
        return _apiClient.GetFollowersCount(followerId);
    }
}

public static class InterfaceCaller
{
    public static void App()
    {
        var service = new FollowingService(new RealApiClient()); 
        service.FollowAndGetFollowersCount("Adam", "Eva");
    }

    public static void Test()
    {
        var mock = new MockApiClient();
        var service = new FollowingService(mock); 
        
        service.FollowAndGetFollowersCount("Adam", "Eva");
        
        if (mock.Followed[0] != "Eva")
            Console.WriteLine("TEST FAILED");
    }
}

public class RealApiClient : IApiClient
{
    public int GetFollowersCount(string userId)
    {
        // TODO request for real API
        throw new NotImplementedException();
    }

    public List<string> GetFollowers(string userId)
    {
        // TODO request for real API
        throw new NotImplementedException();
    }

    public void FollowUser(string userId, string followerId)
    {
        // TODO request for real API
        throw new NotImplementedException();
    }
}