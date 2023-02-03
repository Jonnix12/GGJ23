using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoSingleton<PlayerManager>
    {
        [SerializeField] private int _hp;
        [SerializeField] private PlayerInputHandler _playerInputHandler;
        [SerializeField] private PlayerWeaponHandler _playerWeaponHandler;

        public PlayerInputHandler PlayerInputHandler => _playerInputHandler;
        public PlayerWeaponHandler PlayerWeaponHandler => _playerWeaponHandler;

        public void DoDamage(int demage)
        {
            _hp -= demage;
        }
    }
}