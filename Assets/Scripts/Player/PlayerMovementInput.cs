using UnityEngine;
using System.Collections;

namespace Player
{
    public class PlayerMovementInput : MonoBehaviour
    {
        [SerializeField] private int _speed;
        [SerializeField] private float _dodgeTime;

        private PlayerInputSystem _playerInputSystem;
        private Vector2 move;

        private void Awake()
        {
            _playerInputSystem = new PlayerInputSystem();
            _playerInputSystem.Player.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
            _playerInputSystem.Player.Move.canceled += ctx => move = Vector2.zero;
            _playerInputSystem.Player.Dodge.performed += ctx => Dodge();
        }

        private void Update()
        {
            Move();
        }

        private void Dodge()
        {
            StartCoroutine(DoDodge());
        }

        private IEnumerator DoDodge()
        {
            _playerInputSystem.Player.Dodge.Disable();
            Sprite sprite = PlayerManager.Instance.SpriteRenderer.sprite;
            PlayerManager.Instance.SpriteRenderer.sprite = null;
            yield return new WaitForSeconds(_dodgeTime);
            PlayerManager.Instance.SpriteRenderer.sprite = sprite;
            _playerInputSystem.Player.Dodge.Enable();
        }

        private void Move()
        {
            Vector2 m = new Vector2(move.x, move.y).normalized * Time.deltaTime * _speed;
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