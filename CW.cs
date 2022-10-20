namespace CSharp_CODAPI
{
    public class CW
    {
        public async Task<BaseAPIResponse?> fullData(string gamertag, Platforms platform)
        {
            (gamertag, var platformStr, var lookupType) = Helpers.mapGamertagToPlatform(gamertag, platform);
            return await Http.sendRequest<BaseAPIResponse>($"/stats/cod/v1/title/cw/platform/{platformStr}/{lookupType}/{gamertag}/profile/type/mp");
        }

        public async Task<BaseAPIResponse?> combatHistory(string gamertag, Platforms platform)
        {
            (gamertag, var platformStr, var lookupType) = Helpers.mapGamertagToPlatform(gamertag, platform);
            return await Http.sendRequest<BaseAPIResponse>($"/crm/cod/v2/title/cw/platform/{platformStr}/{lookupType}/{gamertag}/matches/mp/start/0/end/0/details");
        }

        public async Task<BaseAPIResponse?> combatHistory(string gamertag, Platforms platform, long startTime, long endTime)
        {
            (gamertag, var platformStr, var lookupType) = Helpers.mapGamertagToPlatform(gamertag, platform);
            return await Http.sendRequest<BaseAPIResponse>($"/crm/cod/v2/title/cw/platform/{platformStr}/{lookupType}/{gamertag}/matches/mp/start/{startTime}/end/{endTime}/details");
        }

        public async Task<BaseAPIResponse?> breakdown(string gamertag, Platforms platform)
        {
            (gamertag, var platformStr, var lookupType) = Helpers.mapGamertagToPlatform(gamertag, platform);
            return await Http.sendRequest<BaseAPIResponse>($"/crm/cod/v2/title/cw/platform/{platformStr}/{lookupType}/{gamertag}/matches/mp/start/0/end/0");
        }

        public async Task<BaseAPIResponse?> breakdown(string gamertag, Platforms platform, long startTime, long endTime)
        {
            (gamertag, var platformStr, var lookupType) = Helpers.mapGamertagToPlatform(gamertag, platform);
            return await Http.sendRequest<BaseAPIResponse>($"/crm/cod/v2/title/cw/platform/{platformStr}/{lookupType}/{gamertag}/matches/mp/start/{startTime}/end/{endTime}");
        }

        public async Task<BaseAPIResponse?> seasonLoot(string gamertag, Platforms platform)
        {
            (gamertag, var platformStr, var lookupType) = Helpers.mapGamertagToPlatform(gamertag, platform);
            return await Http.sendRequest<BaseAPIResponse>($"/loot/title/cw/platform/{platformStr}/{lookupType}/{gamertag}/status/en");
        }

        public async Task<BaseAPIResponse?> mapList(Platforms platform)
        {
            (_, var platformStr, _) = Helpers.mapGamertagToPlatform(string.Empty, platform);
            return await Http.sendRequest<BaseAPIResponse>($"/ce/v1/title/cw/platform/${platformStr}/gameType/mp/communityMapData/availability");
        }

        public async Task<BaseAPIResponse?> matchInfo(string matchId, Platforms platform)
        {
            (_, var platformStr, _) = Helpers.mapGamertagToPlatform(string.Empty, platform);
            return await Http.sendRequest<BaseAPIResponse>($"/crm/cod/v2/title/cw/platform/{platformStr}/fullMatch/mp/{matchId}/en");
        }
    }
}
