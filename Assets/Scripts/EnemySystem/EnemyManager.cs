using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private Transform _spwonPoint;
        [SerializeField] private CircleCollider2D _playerLong;
        [SerializeField] private CircleCollider2D _playerSort;
        [SerializeField] private float _xOffset;
        
        [SerializeField] private List<EnemyData> _enemyDatas;
        private List<Enemy> _enemies;

        private void Start()
        {
            _enemies = new List<Enemy>();
            
            foreach (var enemyData in _enemyDatas)
            {
                var cahce = EnemyFactory.Instance.GetEnemy(enemyData);
                cahce.transform.position = _spwonPoint.position;
                _enemies.Add(cahce);
                
            }
        }

        private void Update()
        {
          
        }

        private void RemoveEnemy(Enemy enemy)
        {
            _enemies.Remove(enemy);
            enemy.Dispose();
        }
    }
}