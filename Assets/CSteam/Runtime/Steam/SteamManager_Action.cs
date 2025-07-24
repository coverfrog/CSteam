using System;
using UnityEngine;

namespace Cf.CSteam
{
    public partial class SteamManager
    {
        public event Action OnActNetworkSpawn;
        
        public event Action OnActNetworkDespawn;
    }
}
