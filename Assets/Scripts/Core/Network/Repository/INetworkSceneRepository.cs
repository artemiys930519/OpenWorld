using Core.Network.Units;

namespace Core.Network.Repository
{
    public interface INetworkSceneRepository
    {
        public void RegisterPlayer(NetworkPlayer player);
        public NetworkPlayer GetPlayer();
    }
}