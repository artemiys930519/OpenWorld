using Core.Services.Repository;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Core.Game.Units
{
    public class Player : MonoBehaviour
    {
        #region Inspector
        [field:SerializeField]public GameObject CameraLookTarget { get; private set; }
        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private StarterAssetsInputs _starterAssetsInputs;
        [SerializeField] private BasicRigidBodyPush _basicRigidBodyPush;
        #endregion

        [Inject]
        private void Construct(ISceneRepository sceneRepository)
        {
            sceneRepository.RegisterPlayer(gameObject);
        }
    }
}