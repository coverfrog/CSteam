using System.Collections.Generic;
using Steamworks;
using UnityEngine.SceneManagement;

namespace Cf.CSteam
{
    public partial class SteamManager
    {
        private void SubSteam()
        {
            SteamMatchmaking.OnLobbyCreated += LobbyCreated;
            SteamMatchmaking.OnLobbyEntered += LobbyEntered;
            SteamMatchmaking.OnLobbyMemberJoined += LobbyMemberJoined;
            SteamMatchmaking.OnLobbyMemberLeave += LobbyMemberLeave;
            SteamMatchmaking.OnChatMessage += ChatMessaged;
            
            SteamFriends.OnGameLobbyJoinRequested += GameLobbyJoinRequested;
        }

        private void SubScene()
        {
            Net.SceneManager.OnLoadEventCompleted += SceneLoadEventCompleted;
        }
    }
}