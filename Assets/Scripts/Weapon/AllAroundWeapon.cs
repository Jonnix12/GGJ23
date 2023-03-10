using Pool;
using Projectile;
using UnityEngine;

namespace Weapon
{
    public class AllAroundWeapon : BaseWeapon
    {
        [SerializeField] int _amountOfProjectiles = 12;

        public override void Shoot(Quaternion quaternion, float angle, Transform spawnPosition)
        {
            if (_amountOfProjectiles > 1)
            {
                base.Shoot(quaternion, angle, spawnPosition);
                float angleToAdd = 360 / _amountOfProjectiles;
                for (int i = 0; i < _amountOfProjectiles-1; i++)
                {
                    angle += angleToAdd;
                    base.Shoot(quaternion,angle, spawnPosition);
                }
            }

            else
                base.Shoot(quaternion, angle, spawnPosition);
        }

    }

}