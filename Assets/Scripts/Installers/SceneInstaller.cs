using Core.Infractructure.Factory;
using Core.Infractructure.StateMachine;
using Core.Network.Repository;
using Core.Services;
using ScriptableObjects;
using UnityEngine;
using Zenject;
using IFactory = Core.Infractructure.Factory.IFactory;

namespace Installers
{
    public class SceneInstaller : MonoInstaller<SceneInstaller>
    {
        [SerializeField] private SceneNetworkSettings _sceneNetworkSettings;
        
        public override void InstallBindings()
        {
            //SignalBusInstaller.Install(Container);
            //Container.DeclareSignal<RaiseEnemySignal>();

            Container.Bind<INetworkWorldContext>().To<NetworkWorldContext>().AsSingle().WithArguments(_sceneNetworkSettings);
            Container.Bind<IFactory>().To<Factory>().AsTransient();
            Container.Bind<INetworkSceneRepository>().To<NetworkSceneRepository>().AsTransient();
            Container.Bind<StateMachine>().AsSingle();
        }
    } 
}

