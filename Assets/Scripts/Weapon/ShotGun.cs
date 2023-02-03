using UnityEngine;
using Player;

namespace Weapon
{
    public class ShotGun : BaseWeapon
    {
        [SerializeField] private float angleBetweenProjectiles;
        public override void Shoot(Quaternion quaternion, float angle, Transform spawnPosition)
        {
            GameObject projectile = Instantiate(_projectile, spawnPosition.transform.position + spawnPosition.transform.forward * 10, quaternion);
            projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            angle += angleBetweenProjectiles;
            GameObject secondProjectile = Instantiate(_projectile, spawnPosition.transform.position + spawnPosition.transform.forward * 10, quaternion);
            secondProjectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            angle -= angleBetweenProjectiles*2;
            GameObject thirdProjectile = Instantiate(_projectile, spawnPosition.transform.position + spawnPosition.transform.forward * 10, quaternion);
            thirdProjectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

}
