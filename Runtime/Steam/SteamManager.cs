using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Netcode.Transports.Facepunch;
using Steamworks;
using Steamworks.Data;
using Unity.Netcode;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Cf.CSteam
{
    public partial class SteamManager : NetworkBehaviour
    {
        private static NetworkManager Net { get; set; }

        private static FacepunchTransport Transport { get; set; }

        private static Lobby CurrentLobby { get; set; }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private IEnumerator Start()
        {
            SubSteam();

            yield return CoLoadNetworkManager();
        }

        public override void OnDestroy()
        {
            UnSubSteam();
        }

        public override void OnNetworkSpawn()
        {
            SubScene();
        }

        public override void OnNetworkDespawn()
        {
            UnSubScene();
        }

        private IEnumerator CoLoadNetworkManager()
        {
            const float timeOut = 0.5f;
            const string path = "Network Manager";
            
            float timer = 0.0f;

            _ = NetworkManager.Singleton;
            
            while (!NetworkManager.Singleton && timer < timeOut)
            {
                timer += Time.deltaTime;
                
                yield return null;
            }

            if (NetworkManager.Singleton)
            {
                yield break;
            }

            GameObject obj = (GameObject)Instantiate(Resources.Load(path), Vector3.zero, Quaternion.identity);
            
            Net = obj.GetComponent<NetworkManager>();
            Transport = obj.GetComponent<FacepunchTransport>();
            
        }
    }
}