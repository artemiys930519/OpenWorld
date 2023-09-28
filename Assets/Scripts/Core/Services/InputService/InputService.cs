using UnityEngine;

namespace Core.Services.InputService
{
    public class InputService : IInputService
    {
        private PlayerInput _playerInput = new PlayerInput();

        public InputService()
        {
            _playerInput = new PlayerInput();
            _playerInput.Player.Move.Enable();
            _playerInput.Player.Look.Enable();
        }

        public Vector2 GetMovementValue()
        {
            return _playerInput.Player.Move.ReadValue<Vector2>();
        }

        public Vector2 GetRotationValue()
        {
            return _playerInput.Player.Look.ReadValue<Vector2>();
        }

        public void Disable()
        {
            _playerInput.Player.Move.Disable();
            _playerInput.Player.Look.Disable();
            _playerInput = null;
        }
    }
}