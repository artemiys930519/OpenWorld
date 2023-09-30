using Core.Infractructure.StateMachine;
using Core.Infractructure.StateMachine.States;
using Zenject;

namespace Installers
{
    public class StateMachineInstaller : MonoInstaller<StateMachineInstaller>
        {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InitializeState>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameState>().AsSingle();
            Container.BindInterfacesAndSelfTo<EndState>().AsSingle();
            Container.Bind<StateMachine>().AsSingle();
        }
    } 
}