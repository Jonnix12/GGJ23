using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class ProjectilePool : MonoSingleton<ProjectilePool>
    {
        private Stack<Projectile.Projectile> _pool;

        public override void Awake()
        {
            base.Awake();
            _pool = new Stack<Projectile.Projectile>();
        }

        public Projectile.Projectile Pull(Projectile.Projectile projectile,Transform parent)
        {
            if (_pool.Count <= 0)
            {
                var cache = Instantiate(projectile.gameObject, parent).GetComponent<Projectile.Projectile>();
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
        
        private void AddObjectToPool(Projectile.Projectile projectile)
        {
            projectile.gameObject.SetActive(false);
            _pool.Push(projectile);
        }
    }
}