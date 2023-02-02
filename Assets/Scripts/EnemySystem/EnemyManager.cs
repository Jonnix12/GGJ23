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
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (_enemies[i].Range == Range.Long)
                {
                    var dis = Vector2.Distance(_playerSort.transform.position, _enemies[i].transform.position);
                    var vector2 = new Vector2(_playerSort.transform.position.x + _xOffset,_playerSort.transform.position.y + _xOffset);
                    _enemies[i].UpdateDircastion(vector2);
                }
                if (_enemies[i].Range == Range.Short)
                {
                    var x = Random.Range(_playerSort.transform.position.x - 50, _playerSort.transform.position.x + 50);
                    var y = Random.Range(_playerSort.transform.position.y - 50, _playerSort.transform.position.y + 50);
                    _enemies[i].UpdateDircastion(new Vector2(x,y));
                }
            }
        }

        private void RemoveEnemy(Enemy enemy)
        {
            _enemies.Remove(enemy);
            enemy.Dispose();
        }
    }
}