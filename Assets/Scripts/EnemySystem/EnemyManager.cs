using System;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private Transform _spwonPoint;
        [SerializeField] private float _PlayerOfSet;
        [SerializeField] private float _sortDis;
        [SerializeField] private float _longDis;
        
        [SerializeField] private List<EnemyData> _enemyDatas;
        private List<Enemy> _enemies;

        private void Start()
        {
            _enemies = new List<Enemy>();
            
            foreach (var enemyData in _enemyDatas)
            {
                var cahce = EnemyFactory.Instance.GetEnemy(enemyData);
                cahce.transform.position = _spwonPoint.position;
                
                switch(cahce.RangeType)
                {
                    case Range.Short:
                        cahce.SetRange(_sortDis,_PlayerOfSet);
                        break;
                    case Range.Long:
                        cahce.SetRange(_longDis,_sortDis);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                _enemies.Add(cahce);
                
            }
        }

        private void RemoveEnemy(Enemy enemy)
        {
            _enemies.Remove(enemy);
            enemy.Dispose();
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(_player.position,_sortDis);
            Gizmos.DrawWireSphere(_player.position,_longDis);
            Gizmos.DrawWireSphere(_player.position,_PlayerOfSet);
        }
    }
}