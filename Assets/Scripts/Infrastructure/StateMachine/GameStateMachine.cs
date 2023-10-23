using System;
using System.Collections.Generic;
using Infrastructure.StateMachine.States;
using Words;
using Zenject;

namespace Infrastructure.StateMachine
{
    public class GameStateMachine
    {
        
        private static Dictionary<Type, IExitableState> _states;
        private static IExitableState _activeState;

        private readonly GameStartState _startState;
        private readonly MainMenuState _menuState;
        private readonly LoadLevelState _loadLevelState;

        public GameStateMachine(GameStartState startState, MainMenuState menuState, LoadLevelState loadLevelState)
        {
            _startState = startState;
            _menuState = menuState;
            _loadLevelState = loadLevelState;
            _states = new Dictionary<Type, IExitableState>()
            {
                {_startState.GetType(), _startState},
                {_menuState.GetType(), _menuState},
                {_loadLevelState.GetType(), _loadLevelState},
                
            };
        }

        public static void Enter<TState>() where TState : class, IState =>
            ChangeState<TState>().Enter();
        
        public static void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadedState<TPayLoad> =>
            ChangeState<TState>().Enter(payLoad);

        private static TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private static TState GetState<TState>() where TState : class, IExitableState => 
            _states[typeof(TState)] as TState;
    }
}