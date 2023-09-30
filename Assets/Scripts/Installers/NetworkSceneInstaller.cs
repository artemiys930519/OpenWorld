using Core.Infractructure.Factory;
using Core.Network;
using Core.Network.Management;
using Core.Services;
using Core.Services.Repository;
using FishNet.Managing;
using ScriptableObjects;
using UnityEngine;
using Zenject;
using IFactory = Core.Infractructure.Factory.IFactory;

namespace Installers
{
    public class NetworkSceneInstaller : MonoInstaller<NetworkSceneInstaller>
    {
        [SerializeField] private SceneNetworkSettings _sceneNetworkSettings;
        [SerializeField] private NetworkManager _networkManager;
        [SerializeField] private NetworkSceneComposition _networkSceneComposition;
        public override void InstallBindings()
        {
            Container.Bind<INetworkWorldContext>().To<NetworkWorldContext>().AsSingle().WithArguments(_sceneNetworkSettings);
            Container.Bind<INetworkService>().To<FishNetNetworkService>().AsSingle().WithArguments(_networkManager);
            Container.Bind<IFactory>().To<Factory>().AsTransient();
            Container.Bind<ISceneRepository>().To<SceneRepository>().AsSingle();
            Container.Bind<ISceneComposition>().FromInstance(_networkSceneComposition);

        }
    } 
}

