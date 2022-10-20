namespace CSharp_CODAPI
{
    public class SHOP
    {
        public async Task<BaseAPIResponse?> purchasableItems(string gameId)
        {
            return await Http.sendRequest<BaseAPIResponse>($"/inventory/v1/title/{gameId}/platform/psn/purchasable/public/en");
        }

        public async Task<BaseAPIResponse?> bundleInformation(string title, string bundleId)
        {
            return await Http.sendRequest<BaseAPIResponse>($"/inventory/v1/title/{title}/bundle/{bundleId}/en");
        }

        public async Task<BaseAPIResponse?> battlePassLoot(long season, Platforms platform)
        {
            (_, var platformStr, _) = Helpers.mapGamertagToPlatform(string.Empty, platform, true);
            return await Http.sendRequest<BaseAPIResponse>($"/loot/title/mw/platform/{platformStr}/list/loot_season_{season}/en");
        }
    }
}
