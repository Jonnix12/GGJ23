using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class EnemyPool : MonoBehaviour
    {
        [SerializeField] private Transform _paren;
        [SerializeField] private List<Enemy> _enemys;
        private Dictionary<int, Enemy> _objects;
        private Dictionary<int, Stack<Enemy>> _pools;

        private void Awake()
        {
            _pools = new Dictionary<int, Stack<Enemy>>();
            _objects = new Dictionary<int, Enemy>();
            
            foreach (var enemy in _enemys)
            {
                _objects.Add(enemy.ID,enemy);
                _pools.Add(enemy.ID,new Stack<Enemy>());
            }
        }

        private void AddEnemyToPool(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);

            var pool = _pools[enemy.ID];
            pool.Push(enemy);
        }

        public Enemy PullEnemy(int id)
        {
            var pool = _pools[id];

            if (pool.Count <= 0)
            {
                var cache = Instantiate(_objects[id].gameObject, _paren).GetComponent<Enemy>();
                cache.OnDispos += AddEnemyToPool;
                return cache;
            }
            else
            {
                var cache = pool.Pop();
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