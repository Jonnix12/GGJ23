using UnityEngine;

namespace Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        [SerializeField] PlayerMovementInput _playerMovement;
        [SerializeField] PlayerWeaponInput _playerWeapon;

        public PlayerMovementInput PlayerMovementInput => _playerMovement;
        public PlayerWeaponInput PlayerWeaponInput => _playerWeapon;
    }
}
