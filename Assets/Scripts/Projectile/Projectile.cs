using System;
using UnityEngine;

namespace Projectile
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        [SerializeField] private float _maxLifeTime;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private ProjectileWho _projectileWho;

        private Vector3 _dirction;
        private float _currentLifetime;

        private void Update()
        {
            //_rb.AddForce(transform.forward * _speed);
            transform.position += transform.up * _speed * Time.deltaTime;
            _currentLifetime += Time.deltaTime;
            if (_currentLifetime >= _maxLifeTime)
                Exploed();
        }

        private void Exploed()
        {
            Destroy(this.gameObject);
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
                    if(col.gameObject.TryGetComponent(out Player.Player player))
                    {
                        player.DoDamage(_damage);
                        Exploed();
                    }
                    break;
                default:
                    Exploed();
                    break;
            }

        }
    }

    public enum ProjectileWho
    {
        Player,Enemy
    }
}