using Core.Game.Systems;
using Core.Services.InputService;
using FishNet.Object;
using UnityEngine;
using Zenject;

namespace Core.Game.Units
{
    public class Player : NetworkBehaviour
    {
        #region Inspector

        [SerializeField] private Camera _playerCamera;
        [SerializeField] private MovementSystem _movementSystem;

        #endregion

        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        public override void OnStartNetwork()
        {
            
        }

        public override void OnStartClient()
        {
            Debug.Log("isowner");
            _playerCamera.gameObject.SetActive(IsOwner);
            
            if(!IsOwner)
                _inputService.Disable();
            
            _movementSystem.enabled = IsOwner;
        }

        private void Update()
        {
            if (!IsOwner)
                return;
            
            _movementSystem.Move(_inputService.GetMovementValue());
            _movementSystem.Rotate(_inputService.GetRotationValue());
        }
    }
}