using Core.Network.Units;

namespace Core.Network.Repository
{
    public class NetworkSceneRepository : INetworkSceneRepository
    {
        private NetworkPlayer _player;
        
        public void RegisterPlayer(NetworkPlayer player)
        {
            _player = player;
        }

        public NetworkPlayer GetPlayer()
        {
            return _player;
        }
    }
}