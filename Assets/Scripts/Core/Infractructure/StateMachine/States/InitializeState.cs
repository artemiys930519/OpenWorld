using Core.Data;
using Core.Infractructure.Factory;
using Core.Infractructure.SceneLoader;
using Core.Infractructure.StateMachine.Repository;
using Core.Services.SceneComposition;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Infractructure.StateMachine.States
{
    public class InitializeState : IPayloadedState<Transform>
    {
        private IFactory _factory;
        private StateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        private readonly IStateRepository _stateRepository;
        private readonly ISceneComposition _sceneComposition;

        public InitializeState(IFactory factory, ISceneLoader sceneLoader, IStateRepository stateRepository, ISceneComposition sceneComposition)
        {
            _sceneComposition = sceneComposition;
            _sceneLoader = sceneLoader;
            _stateRepository = stateRepository;
            _factory = factory;
            Init();
        }

        public void Init()
        {
            _stateRepository.AddState(this);
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
            _sceneComposition.InitSceneSettings();
        }

        public void Exit()
        {
            
        }
    }
}