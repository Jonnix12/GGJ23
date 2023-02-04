using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
namespace UI
{
    public class PauseMenu : MonoSingleton<PauseMenu>
    {
        [SerializeField] GameObject _pauseMenu;
        [SerializeField] GameObject _tutorialPanel;
        private PlayerInputSystem _playerInputSystem;

        public override void Awake()
        {
            base.Awake();
            _playerInputSystem = new PlayerInputSystem();
            _playerInputSystem.Menu.CloseMenu.performed += ctx => Continue();
            _playerInputSystem.TutorialMenu.GoBack.performed += ctx => SetActiveTutorial(false);
        }

        public void OpenPauseMenu()
        {
            PlayerManager.Instance.PlayerInputHandler.PlayerUIInputHandler.SetActivePlayerInput(false);
            Time.timeScale = 0;
            _pauseMenu.SetActive(true);
        }

       public void Continue()
        {
            PlayerManager.Instance.PlayerInputHandler.PlayerUIInputHandler.SetActivePlayerInput(true);
            Time.timeScale = 1;
            _pauseMenu.SetActive(false);
        }

        public void SetActiveTutorial(bool toActive)
        {
            if(toActive)
            {
                _tutorialPanel.SetActive(true);
                _pauseMenu.SetActive(false);
                _playerInputSystem.Menu.Disable();
                _playerInputSystem.TutorialMenu.Enable();
            }

            else
            {
                _pauseMenu.SetActive(true);
                _tutorialPanel.SetActive(false);
                _playerInputSystem.Menu.Enable();
                _playerInputSystem.TutorialMenu.Disable();
            }
        }

        public void Quit()
        {
            Application.Quit();
        }

        private void OnEnable()
        {
            _playerInputSystem.Menu.Enable();
        }

        private void OnDisable()
        {
            _playerInputSystem.Menu.Disable();
        }
    }
}


