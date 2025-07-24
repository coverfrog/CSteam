using System.Linq;
using Steamworks;
using Steamworks.Data;
using UnityEngine.SceneManagement;

namespace Cf.CSteam
{
    public partial class SteamManager
    {
        public void LoadScene(string sceneName, LoadSceneMode loadSceneMode)
        {
            Net.SceneManager.LoadScene(sceneName, loadSceneMode);
        }
        
        public async void StartHost(int count = 4)
        {
            await SteamMatchmaking.CreateLobbyAsync(count);
        }

        public void Leave()
        {
            Net.Shutdown();
        }
        
        public async void JoinWithId(ulong id)
        {
            Lobby[] lobbyArr = await SteamMatchmaking.LobbyList.WithSlotsAvailable(1).RequestAsync();

            Lobby lobby = lobbyArr.FirstOrDefault(l => l.Id == id);

            await lobby.Join();
        }

        public void SendChat(string message)
        {
            CurrentLobby.SendChatString(message);
        }
    }
}