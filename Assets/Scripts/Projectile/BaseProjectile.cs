using System;
using Pool;
using UnityEngine;

namespace Projectile
{

    public class BaseProjectile : MonoBehaviour,IPoolable<BaseProjectile>,IDisposable
    {
        [SerializeField] private int _id;
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        [SerializeField] private float _maxLifeTime;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private ProjectileWho _projectileWho;

        private Vector3 _dirction;
        private float _currentLifetime;

        public int ID => _id;

        private void Update()
        {
            //_rb.AddForce(transform.forward * _speed);
            transform.position += transform.up * _speed * Time.deltaTime;
            _currentLifetime += Time.deltaTime;
            if (_currentLifetime >= _maxLifeTime)
            {
                Exploed();
            }
        }

        public void Reset()
        {
            _currentLifetime = 0;
        }

        private void Exploed()
        {
            Dispose();
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            switch (_projectileWho)
            {
                case ProjectileWho.Player:
                    if (col.gameObject.TryGetComponent(out Enemy enemy))
                    {
                        enemy.DoDamage(_damage);
                        Debug.Log("Hit enemy");
                        Exploed();
                    }
                    break;
                case ProjectileWho.Enemy:
                    if(col.gameObject.TryGetComponent(out Player.PlayerManager player))
                    {
                        player.DoDamage(_damage);
                        Exploed();
                        Debug.Log("Hit player");
                    }
                    break;
                default:
                    Exploed();
                    Debug.Log("Hit something");
                    break;
            }

        }

        public event Action<BaseProjectile> OnDispos;

        public void Dispose()
        {
            OnDispos?.Invoke(this);
        }
    }

    public enum ProjectileWho
    {
        Player,Enemy
    }
}