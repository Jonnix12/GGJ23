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
        public virtual void Shoot(Quaternion quaternion, float angle, Transform spawnPosition)
        {
            BaseProjectile projectile = ProjectilePool.Instance.Pull(_projectile, null);
            projectile.transform.position = spawnPosition.position;
            projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}

