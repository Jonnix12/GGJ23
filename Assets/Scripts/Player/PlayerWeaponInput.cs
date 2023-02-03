using UnityEngine;
using Projectile;

namespace Player
{
    public class PlayerWeaponInput : MonoBehaviour
    {
        [SerializeField] GameObject _indicator;
        [SerializeField] private Transform _spawnPoint;
        private PlayerInputSystem _playerInputSystem;
        private Vector2 _rotation;
        private float _angle;

        private void Awake()
        {
            _playerInputSystem = new PlayerInputSystem();
            _playerInputSystem.Player.Rotate.performed += ctx => _rotation = ctx.ReadValue<Vector2>();
            _playerInputSystem.Player.Rotate.performed += ctx => _rotation = ctx.ReadValue<Vector2>();
            _playerInputSystem.Player.Shoot.performed += ctx => ShootProjectile();
            _playerInputSystem.Player.SwitchToRightWeapon.performed += ctx => PlayerManager.Instance.PlayerWeaponHandler.ChangeWeapon(true,_angle);
            _playerInputSystem.Player.SwitchToLeftWeapon.performed += ctx => PlayerManager.Instance.PlayerWeaponHandler.ChangeWeapon(false,_angle);
        }

        private void Update()
        {
            Rotate();
        }

        private void Rotate()
        {
            if (_rotation.x == 0 && _rotation.y == 0)
                return;
            _angle = Mathf.Atan2(-_rotation.x, _rotation.y) * Mathf.Rad2Deg;
            _indicator.transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
            PlayerManager.Instance.PlayerWeaponHandler.ChangeSpriteByRotation(_angle);
        }

        private void ShootProjectile()
        {
            Quaternion quaternion = new Quaternion(-_rotation.x, _rotation.y, 0, 0);
            PlayerManager.Instance.PlayerWeaponHandler.CurrentWeapon.Shoot(quaternion, _angle, _spawnPoint);
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
