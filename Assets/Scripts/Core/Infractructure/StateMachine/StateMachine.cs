using System;
using System.Collections.Generic;
using Core.Infractructure.Factory;
using Core.Infractructure.StateMachine.States;

namespace Core.Infractructure.StateMachine
{
    public class StateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states = new();
        private IExitableState _activeState;

        public StateMachine(InitializeState initializeState, GameState gameState)
        {
            _states[typeof(InitializeState)] = initializeState;
            _states[typeof(GameState)] = gameState;
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

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}