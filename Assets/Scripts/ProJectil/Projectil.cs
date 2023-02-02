using UnityEngine;

namespace ProJectil
{
    public class Projectil : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        private Vector2 _dirction;
        
        public void Fire(Vector2 dircsian)
        {
            _dirction = dircsian;
        }

        private void Update()
        {
            transform.position = (Vector2)transform.position + _dirction * _speed;
        }

        private void Exploed()
        {
            Destroy(this);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out Player.Player player))
            {
                player.DoDamage(_damage);
            }
            
            Exploed();
        }
    }
}