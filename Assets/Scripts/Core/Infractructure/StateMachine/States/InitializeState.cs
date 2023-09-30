using Core.Data;
using Core.Infractructure.Factory;
using Core.Infractructure.SceneLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Infractructure.StateMachine.States
{
    public class InitializeState : IPayloadedState<Transform>
    {
        private IFactory _factory;
        private StateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public InitializeState(IFactory factory, ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;

            _factory = factory;
        }

        public async void Enter(Transform payload)
        {
            await _sceneLoader.LoadSceneAsync(SceneData.EnviromentSceneName, LoadSceneMode.Additive);

            GameObject tempPlayerPrefab = await _factory.CreatePlayer(payload.position, payload.rotation.eulerAngles);

            if (tempPlayerPrefab.TryGetComponent(out CharacterController character))
            {
                character.enabled = false;
                tempPlayerPrefab.transform.SetPositionAndRotation(payload.position, payload.rotation);
                character.enabled = true;
            }
        }

        public void Exit()
        {
            
        }
    }
}