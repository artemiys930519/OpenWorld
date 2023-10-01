namespace Core.Infractructure.StateMachine.States
{
    public interface IPayloadedState<TPayload> : IInitialState
    {
        void Enter(TPayload payload);
    }
}