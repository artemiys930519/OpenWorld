﻿using System;
using Core.Services;
using FishNet.Managing;
using UnityEngine;
using Zenject;

namespace Core.Network.Management
{
    public class FishNetNetworkService : MonoBehaviour, INetworkService
    {
        private const string PORT = "PORT";

        #region Inspector

        [SerializeField] private NetworkManager _networkManager;

        #endregion

        private INetworkWorldContext _networkWorldContext;

        private ushort port = 0;

        [Inject]
        private void Construct(INetworkWorldContext networkWorldContext)
        {
            _networkWorldContext = networkWorldContext;
            _networkManager.TransportManager.Transport.SetPort(_networkWorldContext.Port);
            _networkManager.TransportManager.Transport.SetClientAddress(_networkWorldContext.IP);
        }

        public void StartServer()
        {
            if (_networkManager == null)
                return;
            if (ushort.TryParse(Environment.GetEnvironmentVariable(PORT), out ushort result))
            {
                port = result;
            }

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