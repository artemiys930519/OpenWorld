using Cysharp.Threading.Tasks;
using UnityEngine;
using NetworkPlayer = Core.Network.Units.NetworkPlayer;

namespace Core.Network.Repository
{
    public interface INetworkSceneRepository
    {
        public void RegisterPlayer(NetworkPlayer player);
        
        public UniTask<NetworkPlayer> GetLocalPlayer();
    }
}