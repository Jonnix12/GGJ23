using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        
        [SerializeField] private List<EnemyData> _enemyDatas;
        private List<Enemy> _enemies;

        private void Start()
        {
            //GetAllEnemy
        }

        private void RemoveEnemy(Enemy enemy)
        {
            _enemies.Remove(enemy);
            enemy.Dispose();
        }
    }
}