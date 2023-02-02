using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovementInput : MonoBehaviour
    {
        [SerializeField] private int _speed;

        private PlayerInputSystem _playerInputSystem;
        private Vector2 move;

        private void Awake()
        {
            _playerInputSystem = new PlayerInputSystem();
            _playerInputSystem.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
            _playerInputSystem.Player.Move.canceled += ctx => move = Vector2.zero;
        }

        private void Update()
        {
            Vector2 m = (new Vector2(move.x, move.y) * Time.deltaTime * 100f).normalized / 100;
            transform.Translate(m, Space.World);
        }

        private void OnEnable()
        {
            _playerInputSystem.Player.Enable();
        }

        private void OnDisable()
        {
            _playerInputSystem.Player.Disable();
        }
    }
}