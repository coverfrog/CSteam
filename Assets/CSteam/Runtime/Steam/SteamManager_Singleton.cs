using System;
using UnityEngine;

namespace Cf.CSteam
{
    public partial class SteamManager
    {
        private static SteamManager _instance;

        public static SteamManager Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                
                _instance = FindAnyObjectByType<SteamManager>();

                if (_instance == null)
                {
                    _instance = new GameObject("Steam Manager").AddComponent<SteamManager>();
                }

                return _instance;
            }
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }

            else
            {
                Destroy(gameObject);
            }
        }
    }
}