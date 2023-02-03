using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerAnimationHandler : MonoBehaviour
    {
        [SerializeField] SpriteRenderer _playerSpriteRenderer;
        [SerializeField] List<Sprite> _playerIdleSprites; //1:Front, 2:Down, 3:Left, 4:Right
        [SerializeField] Animator _animator;

        public void ChangeIdleSprite(float rotate)
        {
            
            if(rotate >= 135 && rotate <= -135)
                _playerSpriteRenderer.sprite = _playerIdleSprites[0];

            else if (rotate >= -45 && rotate <= 45)
                _playerSpriteRenderer.sprite = _playerIdleSprites[1];

            else if (rotate > 45 && rotate < 135)
                _playerSpriteRenderer.sprite = _playerIdleSprites[2];

            else if (rotate > -135 && rotate <= -45)
                _playerSpriteRenderer.sprite = _playerIdleSprites[3];

            else
            _playerSpriteRenderer.sprite = _playerIdleSprites[0];
        }
    }
}

