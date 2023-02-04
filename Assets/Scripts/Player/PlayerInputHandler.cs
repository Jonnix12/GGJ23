using UnityEngine;

namespace Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] PlayerMovementInput _playerMovement;
        [SerializeField] PlayerWeaponInput _playerWeapon;
        [SerializeField] PlayerUIInputHandler _playerUIInputHandler;

        public PlayerMovementInput PlayerMovementInput => _playerMovement;
        public PlayerWeaponInput PlayerWeaponInput => _playerWeapon;
        public PlayerUIInputHandler PlayerUIInputHandler => _playerUIInputHandler;
    }
}
