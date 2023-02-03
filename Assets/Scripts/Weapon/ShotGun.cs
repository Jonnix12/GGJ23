using UnityEngine;
using Player;
using Pool;
using Projectile;

namespace Weapon
{
    public class ShotGun : BaseWeapon
    {
        [SerializeField] private float angleBetweenProjectiles = 22;
        public override void Shoot(Quaternion quaternion, float angle, Transform spawnPosition)
        {
            base.Shoot(quaternion,angle,spawnPosition);
            // BaseProjectile projectile = ProjectilePool.Instance.Pull(_projectile.ID, null);
            // projectile.transform.position = spawnPosition.parent.position;
            // projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
            base.Shoot(quaternion,angle += angleBetweenProjectiles,spawnPosition);
            angle += angleBetweenProjectiles;
            
            base.Shoot(quaternion,angle -= angleBetweenProjectiles * 2,spawnPosition);
            angle -= angleBetweenProjectiles * 2;
            
        }
    }

}
