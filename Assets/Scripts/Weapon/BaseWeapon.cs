using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Projectile;

namespace Weapon
{
    public class BaseWeapon : MonoBehaviour
    {
        [SerializeField] protected GameObject _projectile;
        public virtual void Shoot(Quaternion quaternion, float angle, Transform spawnPosition)
        {
            GameObject projectile = Instantiate(_projectile, spawnPosition.transform.position + spawnPosition.transform.forward * 10, quaternion);
            projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}

