using Core.Services.Repository;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Core.Game.Units
{
    public class Player : MonoBehaviour , IUnits
    {
        #region Inspector
        [field:SerializeField]public GameObject CameraLookTarget { get; private set; }
        [field:SerializeField]public PlayerInput PlayerInput{ get; private set; }
        [field:SerializeField]public StarterAssetsInputs StarterAssetsInputs{ get; private set; }
        [field:SerializeField]public BasicRigidBodyPush BasicRigidBodyPush{ get; private set; }
        #endregion

        [Inject]
        private void Construct(ISceneRepository sceneRepository)
        {
            sceneRepository.RegisterPlayer(gameObject);
        }
    }
}