namespace SpotifyCompanion
{
    public static class Program
    {
        public static async Task Main()
        {
            var spotify = new App("1d6a111ca15a48a5a5b1f0364147756f", "4c72324c6ce8489ba4f61605b0b0f240");
            await spotify.Login();
            await spotify.Run();
        }
    }
}