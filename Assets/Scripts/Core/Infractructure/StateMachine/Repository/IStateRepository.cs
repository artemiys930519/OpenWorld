using Core.Infractructure.StateMachine.States;

namespace Core.Infractructure.StateMachine.Repository
{
    public interface IStateRepository
    {
        public void AddState(IInitialState state);
        public TState GetState<TState>();
    }
}