using Core.Infractructure.Factory;
using Core.Infractructure.StateMachine;
using Core.Services.InputService;
using Zenject;
using IFactory = Core.Infractructure.Factory.IFactory;

namespace Installers
{
    public class SceneInstaller : MonoInstaller<SceneInstaller>
    {
        
        public override void InstallBindings()
        {
            //SignalBusInstaller.Install(Container);
            //Container.DeclareSignal<RaiseEnemySignal>();
            
            Container.Bind<StateMachine>().AsSingle();
            Container.Bind<IInputService>().To<InputService>().AsTransient();
            Container.Bind<IFactory>().To<Factory>().AsTransient();
        }
    } 
}

