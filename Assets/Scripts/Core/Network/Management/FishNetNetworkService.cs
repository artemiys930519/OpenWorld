using Core.Services;
using FishNet.Managing;
using UnityEngine;
using Zenject;

namespace Core.Network.Management
{
    public class FishNetNetworkService : MonoBehaviour
    {
        [SerializeField] private NetworkManager _networkManager;
        private INetworkWorldContext _networkWorldContext;

        [Inject]
        private void Construct(INetworkWorldContext networkWorldContext)
        {
            _networkWorldContext = networkWorldContext;
        }

        private void Awake()
        {
#if UNITY_SERVER
            StartServer();
#endif
#if !UNITY_SERVER
            StartClient();
#endif
        }

        private void StartServer()
        {
            if (_networkManager == null)
                return;
            _networkManager.TransportManager.Transport.SetPort(_networkWorldContext.Port);

            _networkManager.ServerManager.StartConnection();
        }

        private void StartClient()
        {
            if (_networkManager == null)
                return;
            _networkManager.TransportManager.Transport.SetPort(_networkWorldContext.Port);
            _networkManager.TransportManager.Transport.SetClientAddress(_networkWorldContext.IP);
            _networkManager.ClientManager.StartConnection();
        }
    }
}