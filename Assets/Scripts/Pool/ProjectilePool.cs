using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class ProjectilePool : MonoSingleton<ProjectilePool>
    {
        private Stack<Projectile.BaseProjectile> _pool;

        public override void Awake()
        {
            base.Awake();
            _pool = new Stack<Projectile.BaseProjectile>();
        }

        public Projectile.BaseProjectile Pull(Projectile.BaseProjectile projectile,Transform parent)
        {
            if (_pool.Count <= 0)
            {
                var cache = Instantiate(projectile.gameObject, parent).GetComponent<Projectile.BaseProjectile>();
                cache.OnDispos += AddObjectToPool;
                return cache;
            }
            else
            {
                var cache = _pool.Pop();
                cache.gameObject.SetActive(true);
                cache.Reset();
                return cache;
            }
        }
        
        private void AddObjectToPool(Projectile.BaseProjectile projectile)
        {
            projectile.gameObject.SetActive(false);
            _pool.Push(projectile);
        }
    }
}