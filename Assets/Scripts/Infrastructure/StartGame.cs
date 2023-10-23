using Infrastructure.StateMachine;
using Infrastructure.StateMachine.States;
using UnityEngine;

namespace Infrastructure
{
    public class StartGame : MonoBehaviour
    {
        void Start()
        {
            GameStateMachine.Enter<GameStartState>();   
        }
    }
}
