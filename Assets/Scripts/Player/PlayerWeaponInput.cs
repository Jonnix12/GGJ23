using UnityEngine;

namespace Player
{
    public class PlayerWeaponInput : MonoBehaviour
    {
        [SerializeField] GameObject _indicator;
        [SerializeField] GameObject _projectile;
        private PlayerInputSystem _playerInputSystem;
        private Vector2 rotate;
        private float _angle;

        public float Angle => _angle;
        private void Awake()
        {
            _playerInputSystem = new PlayerInputSystem();
            _playerInputSystem.Player.Rotate.performed += ctx => rotate = ctx.ReadValue<Vector2>();
            _playerInputSystem.Player.Shoot.performed += ctx => ShootProjectile();
        }

        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            if (rotate.x == 0 && rotate.y == 0)
                return;
            float angle = Mathf.Atan2(-rotate.x, rotate.y) * Mathf.Rad2Deg;
            _indicator.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        private void ShootProjectile()
        {
            Quaternion quaternion = new Quaternion(-rotate.x, rotate.y, 0, 0);
            Instantiate(_projectile, transform.position, quaternion);
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
