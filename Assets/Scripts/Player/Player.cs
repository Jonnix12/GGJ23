using UnityEngine;

namespace Player
{
    public class Player : MonoSingleton<Player>
    {
        [SerializeField] private int _hp;
        [SerializeField] private PlayerInputHandler _playerInputHandler;

        public PlayerInputHandler PlayerInputHandler => _playerInputHandler;

        public void DoDamage(int demage)
        {
            _hp -= demage;
        }
    }
}