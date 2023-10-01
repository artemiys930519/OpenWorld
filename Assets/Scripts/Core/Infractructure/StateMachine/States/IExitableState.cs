namespace Core.Infractructure.StateMachine.States
{
    public interface IInitialState
    {
        void Init();
        void Exit();
    }
}