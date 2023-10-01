using System;
using System.Collections.Generic;
using Core.Infractructure.StateMachine.States;

namespace Core.Infractructure.StateMachine.Repository
{
    public class StateRepository : IStateRepository
    {
        private Dictionary<Type, IInitialState> _states = new();

        public void AddState(IInitialState state)
        {
            _states[state.GetType()] = state;
        }


        public TState GetState<TState>()
        {
           return (TState)_states[typeof(TState)];
        }
    }
}