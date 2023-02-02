using UnityEngine;
using Player;

namespace Projectile
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        [SerializeField] private float _maxLifeTime;
        private Vector3 _dirction;
        private float _currentLifetime;

        private void Update()
        {
            transform.position += transform.up * _speed;
            _currentLifetime += Time.deltaTime;
            if (_currentLifetime >= _maxLifeTime)
                Exploed();
        }

        private void Exploed()
        {
            Destroy(this.gameObject);
        }
    }
}