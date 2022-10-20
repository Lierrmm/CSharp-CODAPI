namespace CSharp_CODAPI
{
    public static class CODAPI
    {
        public static bool login(string ssoToken) => Http.login(ssoToken);

        private static MW modernWarfare = new();
        public static MW ModernWarfare { get => modernWarfare; set => modernWarfare = value; }

        private static MW2 modernWarfare2 = new();
        public static MW2 ModernWarfare2 { get => modernWarfare2; set => modernWarfare2 = value; }

        private static WZ warzone = new();
        public static WZ Warzone { get => warzone; set => warzone = value; }

        private static CW coldWar = new();
        public static CW ColdWar { get => coldWar; set => coldWar = value; }

        private static VG vanguard = new();
        public static VG Vanguard { get => vanguard; set => vanguard = value; }

        private static SHOP store = new();
        public static SHOP Store { get => store; set => store = value; }

        private static USER me = new();
        public static USER Me { get => me; set => me = value; }

        private static ALT misc = new();
        public static ALT Misc { get => misc; set => misc = value; }
    }
}
