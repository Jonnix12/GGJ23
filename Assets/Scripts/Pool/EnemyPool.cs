using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private Transform _paren;
        [SerializeField] private Enemy _enemy;
        private Stack<Enemy> _pool;

        public void Start()
        {
            _pool = new Stack<Enemy>();
        }

        private void AddEnemyToPool(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);
            _pool.Push(enemy);
        }

        public Enemy PullEnemy()
        {
            if (_pool.Count <= 0)
            {
                var cache = Instantiate(_enemy.gameObject, _paren).GetComponent<Enemy>();
                cache.OnDispos += AddEnemyToPool;
                return cache;
            }
            else
            {
                var cache = _pool.Pop();
                cache.gameObject.SetActive(true);
                return cache;
            }
        }
    }

    public interface IPoolable<T>
    {
        public event Action<T> OnDispos;
    }
}