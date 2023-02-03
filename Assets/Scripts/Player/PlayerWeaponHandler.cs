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

        public int CurrentWeaponID => _currentWeaponID;

        private void Awake()
        {
            if (_playerWeaponsWheel.Count == 0 || _playerWeaponsWheel == null)
                throw new Exception("PlayerWeaponHandler: No weapons!");

            _currentWeapon = _playerWeaponsWheel[0];
            _currentWeaponID = 0;
            RightWeapon.sprite = null;
        }

        public void ChangeWeapon(bool isNext, float angle)
        {
            if (_playerWeaponsWheel.Count == 1)
                return;

            if (isNext)
            {
                MoveToNextWeapon();
                ChangeSpriteByRotation(angle);
            }

            else
            {
                MoveToPreviousWeapon();
                ChangeSpriteByRotation(angle);
            }
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

        public void ChangeSpriteByRotation(float angle)
        {
            if (angle < 0 )
                ChangeToRightWeaponSprite();

            else if(angle >= 0)
                ChangeToLeftWeaponSprite();
        }

        private void ChangeToRightWeaponSprite()
        {
            LeftWeapon.sprite = null;
            RightWeapon.sprite = _currentWeapon.GetWeaponSprite(true);
        }

        private void ChangeToLeftWeaponSprite()
        {
            RightWeapon.sprite = null;
            LeftWeapon.sprite = _currentWeapon.GetWeaponSprite(false);
        }
    }
}

