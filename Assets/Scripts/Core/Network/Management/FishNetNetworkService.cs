using System;
using Core.Services;
using FishNet.Managing;
using UnityEngine;
using Zenject;

namespace Core.Network.Management
{
    public class FishNetNetworkService : INetworkService
    {
        private const string PORT = "PORT";
        
        private INetworkWorldContext _networkWorldContext;
        private NetworkManager _networkManager;

        private ushort port = 0;
        
        [Inject]
        private void Construct(INetworkWorldContext networkWorldContext,NetworkManager networkManager)
        {
            _networkWorldContext = networkWorldContext;
            _networkManager = networkManager;
            _networkManager.TransportManager.Transport.SetPort(_networkWorldContext.Port);
            _networkManager.TransportManager.Transport.SetClientAddress(_networkWorldContext.IP);
        }

        private void Awake()
        {
#if UNITY_SERVER
            if (ushort.TryParse(Environment.GetEnvironmentVariable(PORT), out ushort result))
            {
                port = result;
            }
            StartServer();
#endif
#if !UNITY_SERVER
            StartClient();
#endif
        }

        public void StartServer()
        {
            if (_networkManager == null)
                return;
            Debug.Log(port);
            _networkManager.TransportManager.Transport.SetPort(port);

            _networkManager.ServerManager.StartConnection();
        }

        public void StartClient()
        {
            if (_networkManager == null)
                return;
            
            _networkManager.ClientManager.StartConnection();
        }
    }
}