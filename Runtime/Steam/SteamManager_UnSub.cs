using Steamworks;

namespace Cf.CSteam
{
    public partial class SteamManager
    {
        private static void UnSubSteam()
        {
            SteamMatchmaking.OnLobbyCreated -= LobbyCreated;
            SteamMatchmaking.OnLobbyEntered -= LobbyEntered;
            SteamMatchmaking.OnLobbyMemberJoined -= LobbyMemberJoined;
            SteamMatchmaking.OnLobbyMemberLeave -= LobbyMemberLeave;
            SteamMatchmaking.OnChatMessage -= ChatMessaged;
            
            SteamFriends.OnGameLobbyJoinRequested -= GameLobbyJoinRequested;
        }
        
        private static void UnSubScene()
        {
            Net.SceneManager.OnLoadEventCompleted -= SceneLoadEventCompleted;
        }
    }
}