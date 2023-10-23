namespace Infrastructure.StateMachine.States
{
    public class MainMenuState: IState
    {
        private MainMenu _mainMenu;

        public MainMenuState(MainMenu mainMenu)
        {
            _mainMenu = mainMenu;
        }

        public void Enter()
        {
            _mainMenu.gameObject.SetActive(true);
            _mainMenu.LoadMenu();
        }

        public void Exit()
        {
            _mainMenu.gameObject.SetActive(false);
        }
    }
}