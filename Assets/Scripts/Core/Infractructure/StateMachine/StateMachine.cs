using Core.Infractructure.StateMachine.Repository;
using Core.Infractructure.StateMachine.States;

namespace Core.Infractructure.StateMachine
{
    public class StateMachine
    {
        private IInitialState _activeState;
        private readonly IStateRepository _stateRepository;

        public StateMachine(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public void Enter<TState>() where TState : class, IState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayloadedState<TPayLoad>
        {
            var state = ChangeState<TState>();
            state.Enter(payLoad);
        }

        private TState ChangeState<TState>() where TState : class, IInitialState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IInitialState
        {
            return _stateRepository.GetState<TState>();
        }
    }
}