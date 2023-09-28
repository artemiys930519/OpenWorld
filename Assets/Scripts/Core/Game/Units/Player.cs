using System;
using Core.Game.Systems;
using Core.Services.InputService;
using FishNet.Connection;
using FishNet.Object;
using UnityEngine;
using Zenject;

namespace Core.Game.Units
{
    public class Player : NetworkBehaviour
    {
        #region Inspector

        [SerializeField] private MovementSystem _movementSystem;

        #endregion

        private IInputService _inputService;

        //[Inject]
        //private void Construct(IInputService inputService)
        //{
        //    _inputService = inputService;
        //}

        public override void OnStartClient()
        {
            Debug.Log("awd");
        }

        public override void OnSpawnServer(NetworkConnection connection)
        {
            Debug.Log("awd"+ nameof(OnSpawnServer));
        }

        public override void OnStartNetwork()
        {
            Debug.Log("awd"+ nameof(OnStartNetwork));
        }

        public override void OnStartServer()
        {
            Debug.Log("awd"+ nameof(OnStartServer));

        }

        private void Update()
        {
            if (!IsOwner)
                return;
            
           // _movementSystem.Move(_inputService.GetMovementValue());
           // _movementSystem.Rotate(_inputService.GetRotationValue());
        }
    }
}