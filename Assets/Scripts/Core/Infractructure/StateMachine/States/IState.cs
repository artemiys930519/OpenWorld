namespace Core.Infractructure.StateMachine.States
{
    public interface IState : IInitialState
    {
        void Enter();
    }
}