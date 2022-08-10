using SpotifyCompanion;
using SpotifyCompanion.Models;
using Track = SpotifyCompanion.Track.Track;
using User = SpotifyCompanion.User.User;

namespace Tests;

public class Tests
{
    private readonly Client _spotify;

    public Tests()
    {
        _spotify = new Client("1d6a111ca15a48a5a5b1f0364147756f", "4c72324c6ce8489ba4f61605b0b0f240");
        _spotify.Login().Wait();
    }

    [SetUp]
    public async Task Setup()
    {
        await _spotify.RefreshTokenIfNeeded();
    }

    [Test]
    public async Task Get_Track()
    {
        const string expectedId = "5QO79kh1waicV47BqGRL3g";
        var track = await Track.GetTrack(expectedId);
        
        Assert.AreEqual(expectedId, track.id);
    }

    [Test]
    public async Task Get_Current_User()
    {
        const string expectedName = "gicacean";
        var user = await User.GetCurrentUser();
        
        Assert.AreEqual(expectedName, user.display_name);
    }

    [Test]
    public async Task Get_User_By_Id()
    {
        var currentUser = await User.GetCurrentUser();
        var user = await User.GetUser(currentUser.id);
        
        Assert.AreEqual(currentUser.id, user.id);
    }
}