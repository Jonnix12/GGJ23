using UI;
using UnityEngine;

namespace Player
{
    public class PlayerUIInputHandler : MonoBehaviour
    {
        private PlayerInputSystem _playerInputSystem;
        private void Awake()
        {
            _playerInputSystem = new PlayerInputSystem();
            _playerInputSystem.Player.OpenMenu.performed += ctx => OpenMenu();
        }

        private void OpenMenu()
        {
            SetActivePlayerInput(false);
            PauseMenu.Instance.OpenPauseMenu();
        }

        public void SetActivePlayerInput(bool toActive)
        {
            if(toActive)
                _playerInputSystem.Player.Enable();

            else
                _playerInputSystem.Player.Disable();
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

