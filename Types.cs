using System.Runtime.Serialization;

namespace CSharp_CODAPI
{
    public class generics
    {
        public const string STEAM_UNSUPPORTED = "Steam platform not supported by this game. Try `battle` instead.";
    }

    public class BaseAPIResponse
    {
        public string? status { get; set; }
        public object? data { get; set; }    
    }

    public enum Platforms : int
    {
        [EnumMember(Value = "all")]
        All,
        [EnumMember(Value = "acti")]
        Activision,
        [EnumMember(Value = "battle")]
        Battlenet,
        [EnumMember(Value = "psn")]
        PSN,
        [EnumMember(Value = "steam")]
        Steam,
        [EnumMember(Value = "uno")]
        Uno,
        [EnumMember(Value = "xbl")]
        XBOX
    }
}
