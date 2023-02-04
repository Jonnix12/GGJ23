using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private PlayerInputSystem _playerInputSystem;

    private void Awake()
    {
        _playerInputSystem = new PlayerInputSystem();
        _playerInputSystem.Menu.MoveToNextScene.performed += ctx => MoveToNextScene();

    }

    public void MoveToNextScene()
    {
        SceneManager.LoadScene(1);
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
