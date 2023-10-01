using Core.Infractructure.AssetManagement;
using Core.Infractructure.Factory;
using Core.Infractructure.SceneLoader;
using Core.Infractructure.StateMachine;
using Core.Infractructure.StateMachine.Repository;
using Core.Infractructure.StateMachine.States;
using Core.Network.Management;
using Core.Services;
using Core.Services.Repository;
using Core.Services.SceneComposition;
using ScriptableObjects;
using UnityEngine;
using Zenject;
using IFactory = Core.Infractructure.Factory.IFactory;

namespace Installers
{
    public class NetworkSceneInstaller : MonoInstaller<NetworkSceneInstaller>
    {
        [SerializeField] private SceneNetworkSettings _sceneNetworkSettings;
        [SerializeField] private FishNetNetworkService _fishNetNetworkService;
        [SerializeField] private NetworkSceneComposition _networkSceneComposition;

        public override void InstallBindings()
        {
            Container.Bind<INetworkWorldContext>().To<NetworkWorldContext>().AsSingle()
                .WithArguments(_sceneNetworkSettings);
            Container.Bind<IFactory>().To<Factory>().AsTransient();
            Container.Bind<ISceneRepository>().To<SceneRepository>().AsSingle();
            //scene loader installer
            Container.Bind<ISceneAssets>().To<ScenesInBuildListAssetsProvider>().AsTransient();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsTransient();
            //
            Container.Bind<ISceneComposition>().FromInstance(_networkSceneComposition);
            Container.Bind<INetworkService>().FromInstance(_fishNetNetworkService);
            InitStateMachiine();
        }

        private void InitStateMachiine()
        {
            Container.Bind<IStateRepository>().To<StateRepository>().AsSingle();
            Container.Bind<IInitialState>().To<NetworkState>().AsSingle().NonLazy();
            Container.Bind<StateMachine>().AsSingle();
        }
    }
}