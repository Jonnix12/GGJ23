using UnityEngine;
using Projectile;

namespace Player
{
    public class PlayerWeaponInput : MonoBehaviour
    {
        [SerializeField] GameObject _indicator;
        [SerializeField] GameObject _projectile;
        private PlayerInputSystem _playerInputSystem;
        private Vector2 _idicatorRotation;
        private Vector2 _projectileDirection;
        private float _angle;

        public Vector2 ProjectileDirection => _projectileDirection;
        private void Awake()
        {
            _playerInputSystem = new PlayerInputSystem();
            _playerInputSystem.Player.Rotate.performed += ctx => _idicatorRotation = ctx.ReadValue<Vector2>();
            _playerInputSystem.Player.Shoot.performed += ctx => ShootProjectile();
        }

        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            if (_idicatorRotation.x == 0 && _idicatorRotation.y == 0)
                return;
            _projectileDirection = (new Vector2(_idicatorRotation.x, -_idicatorRotation.y) * Time.deltaTime * 100f).normalized / 100;
            _angle = Mathf.Atan2(-_idicatorRotation.x, _idicatorRotation.y) * Mathf.Rad2Deg;
            _indicator.transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
        }

        private void ShootProjectile()
        {
            Quaternion quaternion = new Quaternion(-_idicatorRotation.x, _idicatorRotation.y, 0, 0);
            GameObject projectile = Instantiate(_projectile, _indicator.transform.position, quaternion);
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
