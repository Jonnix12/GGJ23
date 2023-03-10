using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EnemySystem
{
    public class EnemyManager : MonoBehaviour
    {
        public event Action OnAllEnemyDied;
        
        [SerializeField] private Transform _player;
        [SerializeField] private List<Transform> _spwonPoint;
        [SerializeField, MinMaxSlider(1, 10)] private Vector2 _spownRate;
        [SerializeField, MinMaxSlider(1, 10)] private Vector2 _spownAmount;
        [SerializeField] private int _NumberOfStateEnemys;
        [SerializeField] private float _PlayerOfSet;
        [SerializeField] private float _sortDis;
        [SerializeField] private float _longDis;
        
        [SerializeField] private List<EnemyGtoup> enemyGtoups;
        private List<Enemy> _enemies;

        private void Start()
        {
            _enemies = new List<Enemy>();

            for (int i = 0; i < _NumberOfStateEnemys; i++)
            {
                var cahce = enemyGtoups[Random.Range(0,enemyGtoups.Count)].GetEnemy();

                if (cahce == null)
                {
                    if (!CheckEnd())
                    {
                        continue;
                    }
                }

                cahce.transform.position = _spwonPoint[Random.Range(0,_spwonPoint.Count)].position;
                
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

            StartCoroutine(Spwon());
        }

        IEnumerator Spwon()
        {
            while (true)
            {
                var amount = Random.Range((int)_spownAmount.x, (int)_spownAmount.y);
                for (int i = 0; i < amount; i++)
                {
                    var cahce = enemyGtoups[Random.Range(0,enemyGtoups.Count)].GetEnemy();

                    if (cahce == null)
                    {
                        if (!CheckEnd())
                        {
                            continue;
                        }
                    }
                
                    cahce.transform.position = _spwonPoint[Random.Range(0,_spwonPoint.Count - 1)].position;
                
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

                    cahce.OnEnemyDied += RemoveEnemy;
                    _enemies.Add(cahce);

                }
                
                yield return new WaitForSeconds(Random.Range(_spownRate.x, _spownRate.y));
            }
        }

        private bool CheckEnd()
        {
            foreach (var enemyGtoup in enemyGtoups)
            {
                if (!enemyGtoup._isEmpty)
                {
                    return false;
                }
            }
            StopAllCoroutines();
            OnAllEnemyDied?.Invoke();
            return true;
        }

        private void RemoveEnemy(Enemy enemy)
        {
            enemy.OnEnemyDied -= RemoveEnemy;
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