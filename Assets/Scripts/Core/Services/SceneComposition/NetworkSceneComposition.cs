﻿using Cinemachine;
using Core.Game.Units;
using Core.Services.Repository;
using FishNet.Object;
using UnityEngine;
using Zenject;

namespace Core.Services.SceneComposition
{
    public class NetworkSceneComposition : NetworkBehaviour, ISceneComposition
    {
        #region Inspector

        [SerializeField] private Camera _camera;
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;

        #endregion

        private ISceneRepository _networkSceneRepository;

        [Inject]
        private void Construct(ISceneRepository networkSceneRepository)
        {
            _networkSceneRepository = networkSceneRepository;
        }

        public override void OnStartServer()
        {
            Destroy(_camera.gameObject);
            Destroy(_cinemachineVirtualCamera.gameObject);
        }

        private async void PlayerInit()
        {
            var connectedPlayer = await _networkSceneRepository.GetComponentOnPlayer<IUnits>();
            _cinemachineVirtualCamera.Follow = connectedPlayer.CameraLookTarget.transform;
        }

        public void InitSceneSettings()
        {
            PlayerInit();
        }
    }
}