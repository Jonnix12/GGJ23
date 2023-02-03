using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoSingleton<PlayerManager>
    {
        [SerializeField] private int _hp;
        [SerializeField] private PlayerInputHandler _playerInputHandler;
        [SerializeField] private PlayerWeaponHandler _playerWeaponHandler;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Collider2D _collider2D;
        public PlayerInputHandler PlayerInputHandler => _playerInputHandler;
        public PlayerWeaponHandler PlayerWeaponHandler => _playerWeaponHandler;

        public SpriteRenderer SpriteRenderer => spriteRenderer;
        public Collider2D Collider2D => _collider2D;

        public void DoDamage(int demage)
        {
            _hp -= demage;
        }
    }
}