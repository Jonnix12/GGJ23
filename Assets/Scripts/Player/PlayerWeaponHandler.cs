using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapon;

namespace Player
{
public class PlayerWeaponHandler : MonoBehaviour
{
    [SerializeField] List<BaseWeapon> _playerWeaponsWheel;
    [SerializeField] SpriteRenderer LeftWeapon;
    [SerializeField] SpriteRenderer RightWeapon;

        private BaseWeapon _currentWeapon;
        private int _currentWeaponID;
        public BaseWeapon CurrentWeapon => _currentWeapon;

        private void Awake()
        {
            if (_playerWeaponsWheel.Count == 0 || _playerWeaponsWheel == null)
                throw new Exception("PlayerWeaponHandler: No weapons!");

            _currentWeapon = _playerWeaponsWheel[0];
            _currentWeaponID = 0;
        }

        public void ChangeWeapon(bool isNext)
        {
            if (_playerWeaponsWheel.Count == 1)
                return;

            if (isNext)
                MoveToNextWeapon();

            else
                MoveToPreviousWeapon();
        }

        private void MoveToNextWeapon()
        {
            if (_currentWeaponID + 1 != _playerWeaponsWheel.Count)
            {
                _currentWeaponID++;
                _currentWeapon = _playerWeaponsWheel[_currentWeaponID];
            }

            else
            {
                _currentWeaponID=0;
                _currentWeapon = _playerWeaponsWheel[_currentWeaponID];
            }
        }

        private void MoveToPreviousWeapon()
        {
            if (_currentWeaponID != 0)
            {
                _currentWeaponID--;
                _currentWeapon = _playerWeaponsWheel[_currentWeaponID];
            }

            else
            {
                _currentWeaponID = _playerWeaponsWheel.Count-1;
                _currentWeapon = _playerWeaponsWheel[_currentWeaponID];
            }
        }

        private void ChangeSpriteByRotation()
        {

        }
    }
}

