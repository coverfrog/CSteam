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
        [SerializeField] private string netPrefabPath = "NetworkManager";
        [SerializeField] private float netSingletonTimeOut = 0.1f;
        
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
            float timer = 0.0f;

            _ = NetworkManager.Singleton;
            
            while (!NetworkManager.Singleton && timer < netSingletonTimeOut)
            {
                timer += Time.deltaTime;
                
                yield return null;
            }

            if (NetworkManager.Singleton)
            {
                yield break;
            }

            Object resource = Resources.Load(netPrefabPath);

            if (resource == null)
            {
#if UNITY_EDITOR
                Debug.LogError("Not Found Prefab");
#endif
                yield break;
            }
            
            GameObject obj = (GameObject)Instantiate(resource, Vector3.zero, Quaternion.identity);
            
            Net = obj.GetComponent<NetworkManager>();
            Transport = obj.GetComponent<FacepunchTransport>();
        }
    }
}