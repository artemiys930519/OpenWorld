using System;
using Core.Infractructure.Factory;
using Core.Infractructure.StateMachine;
using Core.Services;
using Core.Services.InputService;
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
            
            Container.Bind<StateMachine>().AsSingle();
            Container.Bind<INetworkWorldContext>().To<NetworkWorldContext>().AsSingle().WithArguments(_sceneNetworkSettings);
            Container.Bind<IInputService>().To<InputService>().AsTransient();
            Container.Bind<IFactory>().To<Factory>().AsTransient();
        }
    } 
}

