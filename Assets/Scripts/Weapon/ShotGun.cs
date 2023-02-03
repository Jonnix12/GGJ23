using UnityEngine;
using Player;
using Pool;
using Projectile;

namespace Weapon
{
    public class ShotGun : BaseWeapon
    {
        [SerializeField] private float angleBetweenProjectiles;
        public override void Shoot(Quaternion quaternion, float angle, Transform spawnPosition)
        {
            BaseProjectile projectile = ProjectilePool.Instance.Pull(_projectile.ID, null);
            projectile.transform.position = spawnPosition.parent.position;
            projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
         
            angle += angleBetweenProjectiles;
            BaseProjectile secondProjectile = ProjectilePool.Instance.Pull(_projectile.ID, null);
            secondProjectile.transform.position = spawnPosition.parent.position;
            secondProjectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            angle -= angleBetweenProjectiles * 2;
            BaseProjectile thirdProjectile = ProjectilePool.Instance.Pull(_projectile.ID, null);
            thirdProjectile.transform.position = spawnPosition.parent.position;
            thirdProjectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

}
