namespace CSharp_CODAPI
{
    public class ALT
    {
        public async Task<BaseAPIResponse?> search(string gamertag, Platforms platform)
        {
            (gamertag, var platformStr, _) = Helpers.mapGamertagToPlatform(gamertag, platform, true);
            return await Http.sendRequest<BaseAPIResponse>($"/crm/cod/v2/platform/{platformStr}/username/{gamertag}/search");
        }
    }
}
