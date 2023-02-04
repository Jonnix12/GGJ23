using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerAnimationHandler : MonoBehaviour
    {
        [SerializeField] SpriteRenderer _playerSpriteRenderer;
        [SerializeField] List<Sprite> _playerIdleSprites; //1:Front, 2:Down, 3:Left, 4:Right
        [SerializeField] Animator _animator;

        public void StopAnimation()
        {
            _animator.SetBool("IsMovingLeft", false);
            _animator.SetBool("IsMovingRight", false);
            _animator.SetBool("IsMovingUp", false);
        }

        public void ChangeIdleSprite(float rotate)
        {

            if (rotate >= 135 && rotate <= -135)
            {
                _playerSpriteRenderer.sprite = _playerIdleSprites[0];
                _animator.SetBool("IsMovingUp", false);
                _animator.SetBool("IsMovingLeft", false);
                _animator.SetBool("IsMovingRight", false);
            }

            else if (rotate >= -45 && rotate <= 45)
            {
                _playerSpriteRenderer.sprite = _playerIdleSprites[1];
                _animator.SetBool("IsMovingUp", true);
                _animator.SetBool("IsMovingLeft", false);
                _animator.SetBool("IsMovingRight", false);
            }

            else if (rotate > 45 && rotate < 135)
            {
                _playerSpriteRenderer.sprite = _playerIdleSprites[2];
                _animator.SetBool("IsMovingUp", false);
                _animator.SetBool("IsMovingLeft", true);
                _animator.SetBool("IsMovingRight", false);
            }

            else if (rotate > -135 && rotate <= -45)
            {
                _playerSpriteRenderer.sprite = _playerIdleSprites[3];
                _animator.SetBool("IsMovingUp", false);
                _animator.SetBool("IsMovingLeft", false);
                _animator.SetBool("IsMovingRight", true);
            }
        }

        public void PlayDashAnimation(float rotate)
        {
            if (rotate > 0 && rotate <= 180)
                _animator.SetTrigger("DashLeft");

            else if(rotate < 0 && rotate > -180)
                _animator.SetTrigger("DashRight");
        }
    }
}

