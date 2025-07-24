using Steamworks;

namespace Cf.CSteam
{
    public partial class SteamManager
    {
        private void UnSubSteam()
        {
            SteamMatchmaking.OnLobbyCreated -= LobbyCreated;
            SteamMatchmaking.OnLobbyEntered -= LobbyEntered;
            SteamMatchmaking.OnLobbyMemberJoined -= LobbyMemberJoined;
            SteamMatchmaking.OnLobbyMemberLeave -= LobbyMemberLeave;
            SteamMatchmaking.OnChatMessage -= ChatMessaged;
            
            SteamFriends.OnGameLobbyJoinRequested -= GameLobbyJoinRequested;
        }
        
        private void UnSubScene()
        {
            Net.SceneManager.OnLoadEventCompleted -= SceneLoadEventCompleted;
        }
    }
}