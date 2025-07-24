using System;
using System.Collections;
using UnityEngine;

namespace Cf.CSteam
{
    public class SteamFriend : MonoBehaviour
    {
        public bool IsInitialized { get; private set; }
        
        private IEnumerator Start()
        {
            yield return CoInitialize();
        }

        private IEnumerator CoInitialize()
        {
            yield return new WaitUntil(() => SteamManager.Instance.Net != null);

            IsInitialized = true;
        }

        private void GetFriendList()
        {
           
        }
    }
}
