using UnityEngine;


namespace Weapon
{
    public class Pistol : BaseWeapon
    {
        public override void Shoot(Quaternion quaternion, float angle, Transform spawnPosition)
        {
            base.Shoot (quaternion, angle, spawnPosition);
        }
    }
}

