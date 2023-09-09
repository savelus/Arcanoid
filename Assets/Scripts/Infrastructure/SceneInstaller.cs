using System.Globalization;
using Infrastructure.StateMachine;
using Infrastructure.States;
using Words;
using Zenject;

namespace Infrastructure
{
    public class SceneInstaller: MonoInstaller
    { 
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AllWordsList>().AsSingle().NonLazy();            
            var stateMachine = new GameStateMachine();
            stateMachine.Enter<GameStartState>();

        }
    }
}