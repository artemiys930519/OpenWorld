using Core.Game.Systems;
using Core.Services.InputService;
using UnityEngine;
using Zenject;

namespace Core.Game.Units
{
    public class Player : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private MovementSystem _movementSystem;

        #endregion

        private IInputService _inputService;


        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Update()
        {

            _movementSystem.Move(_inputService.GetMovementValue());
            _movementSystem.Rotate(_inputService.GetRotationValue());
        }
    }
}