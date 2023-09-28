using System;
using Core.Services;
using FishNet.Managing;
using UnityEngine;
using Zenject;

namespace Core.Network.Management
{
    public class FishNetNetworkManager : MonoBehaviour
    {
        private NetworkManager _networkManager;
        private INetworkWorldContext _networkWorldContext;
        
        [Inject]
        private void Construct(INetworkWorldContext networkWorldContext )
        {
            _networkWorldContext = networkWorldContext;
        }

        private void Start()
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

            _networkManager.ServerManager.StartConnection();
        }

        private void StartClient()
        {
            if (_networkManager == null)
                return;

            _networkManager.ClientManager.StartConnection(_networkWorldContext.IP,_networkWorldContext.Port);
        }
    }
}