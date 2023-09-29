using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Game.Units
{
    public interface IUnits
    {
        public GameObject CameraLookTarget { get; }

        public PlayerInput PlayerInput { get; }
        public StarterAssetsInputs StarterAssetsInputs { get; }
        public BasicRigidBodyPush BasicRigidBodyPush { get; }
    }
}