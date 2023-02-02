using UnityEngine;
using Player;

namespace Projectile
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        private Vector3 _dirction;

        private void Awake()
        {
            _dirction = Player.Player.Instance.PlayerInputHandler.PlayerWeaponInput.ProjectileDirection;
        }

        private void Update()
        {
            transform.position += transform.up;
        }

        private void Exploed()
        {
            Destroy(this);
        }

        //private void OnCollisionEnter(Collision collision)
        //{
        //    if (collision.gameObject.TryGetComponent(out Player.Player player))
        //    {
        //        player.DoDamage(_damage);
        //    }
            
        //    Exploed();
        //}
    }
}