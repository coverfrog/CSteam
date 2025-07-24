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
        
		public bool IsLoaded { get; private set; }

        public NetworkManager Net { get; private set; }

        public FacepunchTransport Transport { get; private set; }

        private Lobby CurrentLobby { get; set; }

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
            
            OnActNetworkSpawn?.Invoke();
        }

        public override void OnNetworkDespawn()
        {
            UnSubScene();
            
            OnActNetworkDespawn?.Invoke();
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
				IsLoaded = true;
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
			IsLoaded = true;
        }
    }
}