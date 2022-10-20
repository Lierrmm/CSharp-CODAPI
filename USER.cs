namespace CSharp_CODAPI
{
    public class USER
    {
        public async Task<BaseAPIResponse?> friendFeed(string gamertag, Platforms platform)
        {
            (gamertag, var platformStr, _) = Helpers.mapGamertagToPlatform(gamertag, platform, true);
            return await Http.sendRequest<BaseAPIResponse>($"/userfeed/v1/friendFeed/platform/{platformStr}/gamer/{gamertag}/friendFeedEvents/en");
        }

        public async Task<BaseAPIResponse?> eventFeed()
        {
            return await Http.sendRequest<BaseAPIResponse>($"/userfeed/v1/friendFeed/rendered/en/{Http.globalSsoToken}");
        }

        public async Task<BaseAPIResponse?> loggedInIdentities()
        {
            return await Http.sendRequest<BaseAPIResponse>($"/crm/cod/v2/identities/{Http.globalSsoToken}");
        }

        public async Task<BaseAPIResponse?> codPoints(string gamertag, Platforms platform)
        {
            (gamertag, var platformStr, _) = Helpers.mapGamertagToPlatform(gamertag, platform, true);
            return await Http.sendRequest<BaseAPIResponse>($"/inventory/v1/title/mw/platform/{platformStr}/gamer/{gamertag}/currency");
        }

        public async Task<BaseAPIResponse?> connectedAccounts(string gamertag, Platforms platform)
        {
            (gamertag, var platformStr, var lookupType) = Helpers.mapGamertagToPlatform(gamertag, platform, true);
            return await Http.sendRequest<BaseAPIResponse>($"/crm/cod/v2/accounts/platform/{platformStr}/{lookupType}/{gamertag}");
        }

        public async Task<BaseAPIResponse?> settings(string gamertag, Platforms platform)
        {
            (gamertag, var platformStr, _) = Helpers.mapGamertagToPlatform(gamertag, platform, true);
            return await Http.sendRequest<BaseAPIResponse>($"/preferences/v1/platform/{platformStr}/gamer/{gamertag}/list");
        }
    }
}
