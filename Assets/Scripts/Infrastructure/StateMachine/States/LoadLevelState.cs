namespace Infrastructure.StateMachine.States
{
    public class LoadLevelState: IState
    {
        private LevelLoader _levelLoader;

        public LoadLevelState(LevelLoader levelLoader)
        {
            _levelLoader = levelLoader;
        }

        public void Enter()
        {
            _levelLoader.gameObject.SetActive(true);
            _levelLoader.StartLevel();
        }

        public void Exit()
        {
            _levelLoader.gameObject.SetActive(false);
            
        }
    }
}