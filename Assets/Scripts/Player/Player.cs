using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private int _hp;
        [SerializeField] private PlayerInputHandler _playerInputHandler;

        public void DoDamage(int demage)
        {
            _hp -= demage;
        }
    }
}