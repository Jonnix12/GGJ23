using System;
using System.Collections.Generic;
using Pool;
using Projectile;
using UnityEngine;
using Weapon;
using Random = UnityEngine.Random;


namespace EnemySystem
{
    public class EnemyFactory : MonoSingleton<EnemyFactory>
    {
        [SerializeField] private EnemyPool _pool;
        public Enemy GetEnemy(EnemyData enemyData)
        {
            Enemy enemy = _pool.PullEnemy(enemyData.ID);

            BaseWeapon weapon;

            switch (enemyData.EnemyShotType)
            {
                case EnemyShotType.Shotgun:
                     weapon = enemy.gameObject.AddComponent<ShotGun>();
                    break;
                case EnemyShotType.Rifle:
                    weapon = enemy.gameObject.AddComponent<Pistol>();
                    break;
                case EnemyShotType.Circle:
                    weapon = enemy.gameObject.AddComponent<AllAroundWeapon>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            weapon.Init(enemyData.Projectil);
            enemy.Init(enemyData.Hp,enemyData.MoveSpeed,enemyData.FireRate,weapon,enemyData.Range,enemyData.ID);
            
            return enemy;
        }

    }
}