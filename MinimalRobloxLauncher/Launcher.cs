namespace MinimalRobloxLauncher
{
    class LauncherArgs // roblox-player:~+launchmode:~+gameinfo:~+launchtime:~+placelauncherurl:~+browsertrackerid:~+robloxLocale:~+gameLocale:~+channel:+LaunchExp:~
    {
        public string Gameinfo;
        public ulong LaunchTime;
        public string PlaceLauncherUrl;
        public ulong BrowserTrackerID;
        public string RobloxLocale;
        public string GameLocale; // dont need any other arguments
    }

    class Launcher
    {
        public static LauncherArgs ParseArgs(string str)
        {
            LauncherArgs returnArgs = new LauncherArgs();

            var args = str.Split('+');

            foreach (string arg in args)
            {
                var argTokens = arg.Split(':');
                switch (argTokens[0])
                {
                    case "gameinfo":
                        returnArgs.Gameinfo = argTokens[1];
                        break;

                    case "launchtime":
                        returnArgs.LaunchTime = ulong.Parse(argTokens[1]);
                        break;

                    case "placelauncherurl":
                        returnArgs.PlaceLauncherUrl = argTokens[1];
                        break;

                    case "browsertrackerid":
                        returnArgs.BrowserTrackerID = ulong.Parse(argTokens[1]);
                        break;

                    case "robloxLocale":
                        returnArgs.RobloxLocale = argTokens[1];
                        break;

                    case "gameLocale":
                        returnArgs.GameLocale = argTokens[1];
                        break;
                }
            }

            return returnArgs;
        }

    }
}
