using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.ComTypes;

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

    public void FollowUser(string userId, string followerId) { }
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