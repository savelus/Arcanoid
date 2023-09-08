using System;
using System.Collections.Generic;
using Infrastructure.States;
using Words;
using Zenject;

namespace Infrastructure.StateMachine
{
    public class GameStateMachine
    {
        
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;
        
        public GameStateMachine()
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(GameStartState)] = new GameStartState(),
            };
        }

        public void Enter<TState>() where TState : class, IState =>
            ChangeState<TState>().Enter();
        
        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadedState<TPayLoad> =>
            ChangeState<TState>().Enter(payLoad);

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