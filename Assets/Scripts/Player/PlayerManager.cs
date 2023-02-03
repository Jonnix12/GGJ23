using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoSingleton<PlayerManager>
    {
        [SerializeField] private int _hp;
        [SerializeField] private PlayerInputHandler _playerInputHandler;
        [SerializeField] private PlayerWeaponHandler _playerWeaponHandler;
        [SerializeField] private PlayerAnimationHandler _playerAnimationHandler;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Collider2D _collider2D;
        public PlayerInputHandler PlayerInputHandler => _playerInputHandler;
        public PlayerWeaponHandler PlayerWeaponHandler => _playerWeaponHandler;
        public PlayerAnimationHandler PlayerAnimationHandler => _playerAnimationHandler;

        public SpriteRenderer SpriteRenderer => spriteRenderer;
        public Collider2D Collider2D => _collider2D;

        public void DoDamage(int demage)
        {
            _hp -= demage;
        }
    }
}