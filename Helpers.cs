using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CSharp_CODAPI
{
    public class Helpers
    {
        public static string? GetEnumMemberValue<T>(T value) where T : struct, IConvertible
        {
            return typeof(T).GetTypeInfo().DeclaredMembers.SingleOrDefault(x => x.Name == value.ToString())
                ?.GetCustomAttribute<EnumMemberAttribute>(false)
                ?.Value ?? string.Empty;
        }

        public static (string, string, string) mapGamertagToPlatform(string gamertag, Platforms platform, bool steamSupport = false)
        {
            var lookupType = "gamer";

            if (!steamSupport && platform.Equals(Platforms.Steam)) throw new Exception(generics.STEAM_UNSUPPORTED);

            if (platform == Platforms.Battlenet || platform == Platforms.Activision || platform == Platforms.Uno)
                if (gamertag.Length > 0) gamertag = HttpUtility.UrlEncode(gamertag);

            if (platform.Equals(Platforms.Uno)) lookupType = "id";
            if (platform.Equals(Platforms.Uno) || platform.Equals(Platforms.Activision))
                platform = Platforms.Uno;

            return (gamertag, GetEnumMemberValue(platform)?.ToLower() ?? "uno", lookupType);
        }
    }
}
