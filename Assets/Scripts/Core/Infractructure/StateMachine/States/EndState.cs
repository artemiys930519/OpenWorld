using Core.Enums;
using UnityEngine;

namespace Core.Infractructure.StateMachine.States
{
    public class EndState : IState
    {
        public void Exit()
        {
            Debug.Log("Exit EndState");

        }

        public void Enter()
        {
            Debug.Log("enter EndState");
        }
    }
}