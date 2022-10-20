using System.Web;

namespace CSharp_CODAPI
{
    public class MW
    {
        public async Task<BaseAPIResponse?> fullData(string gamertag, Platforms platform)
        {
            var lookupType = "gamer";

            if (platform.Equals(Platforms.Steam)) throw new Exception(generics.STEAM_UNSUPPORTED);
            if (platform == Platforms.Battlenet || platform == Platforms.Activision || platform == Platforms.Uno)
                gamertag = HttpUtility.UrlEncode(gamertag);

            if (platform.Equals(Platforms.Uno)) lookupType = "id";
            if (platform.Equals(Platforms.Uno) || platform.Equals(Platforms.Activision))
                platform = Platforms.Uno;

            return await Http.sendRequest<BaseAPIResponse>($"/stats/cod/v1/title/mw/platform/{platform.ToString().ToLower()}/{lookupType}/{gamertag}/profile/type/mp");
        }
    }
}
