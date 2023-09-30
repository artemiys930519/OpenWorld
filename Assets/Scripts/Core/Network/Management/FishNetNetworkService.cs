using System;
using Core.Services;
using FishNet.Managing;
using UnityEditor.Rendering;
using UnityEngine;
using Zenject;

namespace Core.Network.Management
{
    public class FishNetNetworkService : MonoBehaviour
    {
        private const string PORT = "PORT";
        [SerializeField] private NetworkManager _networkManager;
        private INetworkWorldContext _networkWorldContext;

        private ushort port = 0;
        [Inject]
        private void Construct(INetworkWorldContext networkWorldContext)
        {
            _networkWorldContext = networkWorldContext;
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

        private void StartServer()
        {
            if (_networkManager == null)
                return;
            Debug.Log(port);
            _networkManager.TransportManager.Transport.SetPort(port);

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