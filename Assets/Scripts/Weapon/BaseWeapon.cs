using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Projectile;
using Pool;

namespace Weapon
{
    public class BaseWeapon : MonoBehaviour
    {
        [SerializeField] protected BaseProjectile _projectile;
        [SerializeField] Sprite _leftWeaponSprite;
        [SerializeField] Sprite _rightWeaponSprite;

        public virtual void Shoot(Quaternion quaternion, float angle, Transform spawnPosition)
        {
            BaseProjectile projectile = ProjectilePool.Instance.Pull(_projectile.ID, null);
            projectile.transform.position = spawnPosition.position;
            projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        public Sprite GetWeaponSprite(bool isRight)
        {
            if (isRight)
                return _rightWeaponSprite;

            else
                return _leftWeaponSprite;
        }
    }
}

