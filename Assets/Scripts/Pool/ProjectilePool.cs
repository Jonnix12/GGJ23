using System.Collections.Generic;
using Projectile;
using UnityEngine;

namespace Pool
{
    public class ProjectilePool : MonoSingleton<ProjectilePool>
    {
        [SerializeField] private List<BaseProjectile> _projectiles;
        private Dictionary<int, BaseProjectile> _objects;
        private Dictionary<int, Stack<BaseProjectile>> _pools;

        public override void Awake()
        {
            base.Awake();
            _objects = new Dictionary<int, BaseProjectile>();
            _pools = new Dictionary<int, Stack<BaseProjectile>>();
            
            
            foreach (var baseProjectile in _projectiles)
            {
                _pools.Add(baseProjectile.ID,new Stack<BaseProjectile>());
                _objects.Add(baseProjectile.ID,baseProjectile);
            }
        }

        public BaseProjectile Pull(int id,Transform parent)
        {
            var pool = _pools[id];
            
            if (pool.Count <= 0)
            {
                var cache = Instantiate(_objects[id].gameObject, parent).GetComponent<BaseProjectile>();
                cache.OnDispos += AddObjectToPool;
                return cache;
            }
            else
            {
                var cache = pool.Pop();
                cache.gameObject.SetActive(true);
                cache.Reset();
                return cache;
            }
        }
        
        private void AddObjectToPool(BaseProjectile projectile)
        {
            var pool = _pools[projectile.ID];
            
            projectile.gameObject.SetActive(false);
            projectile.Reset();
            pool.Push(projectile);
        }
    }
}