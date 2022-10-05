using SpotifyCompanion;
using SpotifyCompanion.Controllers;

namespace Tests;

public class ArtistTests
{
    private readonly App _spotify;

    public ArtistTests()
    {
        _spotify = new App("1d6a111ca15a48a5a5b1f0364147756f", "4c72324c6ce8489ba4f61605b0b0f240");
        _spotify.Login().Wait();
    }

    [SetUp]
    public async Task Setup()
    {
        await _spotify.RefreshTokenIfNeeded();
    }

    [Test]
    public async Task Get_Artist_By_Id()
    {
        const string expectedId = "1Xyo4u8uXC1ZmMpatF05PJ";
        var artist = await ArtistController.GetArtist(expectedId);
        
        Assert.AreEqual(expectedId, artist.id);
    }

    [Test]
    public async Task Get_Several_Artists()
    {
        const string expectedId = "1Xyo4u8uXC1ZmMpatF05PJ";
        var artists = await ArtistController.GetSeveralArtist(new string[] {expectedId, expectedId});
        
        CollectionAssert.AreEqual(new string[]{"The Weeknd", "The Weeknd"}, new string[]{artists[0].name, artists[1].name});
    }
}