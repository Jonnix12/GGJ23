using Projectile;
using Sirenix.OdinInspector;
using UnityEngine;


namespace EnemySystem
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "MENUNAME", order = 0)]
    public class EnemyData : ScriptableObject
    {
        [Header("Base Stat")]
        [SerializeField] private int _hp;
        [Header("Movement")]
        [SerializeField] private float _moveSpeed;

        [Header("Combat")] [SerializeField] private Range _range;
        [SerializeField] private EnemyShotType _enemyShotType;
        [SerializeField,MinMaxSlider(1,10)] private Vector2 _fireRate;
        [SerializeField] private Projectile.BaseProjectile _projectil;

        public int Hp => _hp;

        public float MoveSpeed => _moveSpeed;

        public Range Range => _range;

        public EnemyShotType EnemyShotType => _enemyShotType;

        public Vector2 FireRate => _fireRate;

        public Projectile.BaseProjectile Projectil => _projectil;
    }
}