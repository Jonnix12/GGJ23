using Projectile;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyFactory : MonoSingleton<EnemyFactory>
    {
        private GameObject _enemyPrefab;
        
        public Enemy GetEnemy(EnemyData enemyData)
        {
            Enemy enemy = Instantiate(_enemyPrefab).GetComponent<Enemy>();
            enemy.Init(enemyData.Hp,enemyData.MoveSpeed,enemyData.Projectil,enemyData.FireRate,enemyData.Range);

            return enemy;
        }

    }
}