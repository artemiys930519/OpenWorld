using Cysharp.Threading.Tasks;
using NetworkPlayer = Core.Network.Units.NetworkPlayer;

namespace Core.Network.Repository
{
    public class NetworkSceneRepository : INetworkSceneRepository
    {
        private NetworkPlayer _player;

        public void RegisterPlayer(NetworkPlayer player)
        {
            _player = player;
        }

        public async UniTask<NetworkPlayer> GetLocalPlayer()
        {
            await UniTask.WaitUntil(()=> _player != null);
            return _player;
        }
    }
}