using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Steamworks;
using Steamworks.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Cf.CSteam
{
    public partial class SteamManager
    {
        private static async void GameLobbyJoinRequested(Lobby lobby, SteamId steamId)
        {
            await lobby.Join();
        }

        private static void LobbyEntered(Lobby lobby)
        {
            CurrentLobby = lobby;

            if (Net.IsHost)
            {
                return;
            }
            
            Transport.targetSteamId = lobby.Owner.Id;
            Net.StartClient();
        }

        private static void LobbyCreated(Result result, Lobby lobby)
        {
            if (result != Result.OK)
            {
                return;
            }
            
            lobby.SetPublic();
            lobby.SetJoinable(true);

            Net.StartHost();
        }
        
        private static void LobbyMemberJoined(Lobby lobby, Friend friend)
        {
            Debug.Log("멤버 입장");
        }
        
        private static void LobbyMemberLeave(Lobby lobby, Friend friend)
        {
            Debug.Log("멤버 퇴장");
        }
        
        private static void ChatMessaged(Lobby lobby, Friend friend, string message)
        {
            Debug.Log("메시지 받음");
        }
        
        private static void SceneLoadEventCompleted(string sceneName, LoadSceneMode loadScenemode, List<ulong> clientsCompleted, List<ulong> clientsTimedOut)
        {
            Debug.Log("이렇게 이벤트 걸면 문제 생김?");
        }
    }
}