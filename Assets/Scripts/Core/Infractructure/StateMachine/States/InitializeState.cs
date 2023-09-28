using Core.Infractructure.Factory;

namespace Core.Infractructure.StateMachine.States
{
    public class InitializeState : IState
    {
        private IFactory _factory;
        private StateMachine _stateMachine;

        public InitializeState(IFactory factory)
        {
            _factory = factory;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
        }
    }
}