namespace CSharp_CODAPI
{
    public class WZ
    {
        public async Task<BaseAPIResponse?> fullData(string gamertag, Platforms platform)
        {
            (gamertag, var platformStr, var lookupType) = Helpers.mapGamertagToPlatform(gamertag, platform);
            return await Http.sendRequest<BaseAPIResponse>($"/stats/cod/v1/title/mw/platform/{platformStr}/{lookupType}/{gamertag}/profile/type/wz");
        }

        public async Task<BaseAPIResponse?> combatHistory(string gamertag, Platforms platform)
        {
            (gamertag, var platformStr, var lookupType) = Helpers.mapGamertagToPlatform(gamertag, platform);
            return await Http.sendRequest<BaseAPIResponse>($"/crm/cod/v2/title/mw/platform/{platformStr}/{lookupType}/{gamertag}/matches/wz/start/0/end/0/details");
        }

        public async Task<BaseAPIResponse?> combatHistory(string gamertag, Platforms platform, long startTime, long endTime)
        {
            (gamertag, var platformStr, var lookupType) = Helpers.mapGamertagToPlatform(gamertag, platform);
            return await Http.sendRequest<BaseAPIResponse>($"/crm/cod/v2/title/mw/platform/{platformStr}/{lookupType}/{gamertag}/matches/wz/start/{startTime}/end/{endTime}/details");
        }

        public async Task<BaseAPIResponse?> breakdown(string gamertag, Platforms platform)
        {
            (gamertag, var platformStr, var lookupType) = Helpers.mapGamertagToPlatform(gamertag, platform);
            return await Http.sendRequest<BaseAPIResponse>($"/crm/cod/v2/title/mw/platform/{platformStr}/{lookupType}/{gamertag}/matches/wz/start/0/end/0");
        }

        public async Task<BaseAPIResponse?> breakdown(string gamertag, Platforms platform, long startTime, long endTime)
        {
            (gamertag, var platformStr, var lookupType) = Helpers.mapGamertagToPlatform(gamertag, platform);
            return await Http.sendRequest<BaseAPIResponse>($"/crm/cod/v2/title/mw/platform/{platformStr}/{lookupType}/{gamertag}/matches/wz/start/{startTime}/end/{endTime}");
        }

        public async Task<BaseAPIResponse?> matchInfo(string matchId, Platforms platform)
        {
            (_, var platformStr, _) = Helpers.mapGamertagToPlatform(string.Empty, platform);
            return await Http.sendRequest<BaseAPIResponse>($"/crm/cod/v2/title/mw/platform/{platformStr}/fullMatch/mp/{matchId}/en");
        }
    }
}
