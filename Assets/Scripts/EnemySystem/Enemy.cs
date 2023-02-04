using System;
using System.Collections;
using Pool;
using UnityEngine;
using Projectile;
using Weapon;
using Random = UnityEngine.Random;


public class Enemy : MonoBehaviour , IDisposable , IPoolable<Enemy>

{
    public event Action<Enemy> OnEnemyDied;

    private int _hp;
    [SerializeField] private ShotHandler _shotHandler;
    [SerializeField] private int _id;
    private float _moveSpeed;

    private Vector2 _dircsation;

    private Range _rangeType;
    private float _rage;
    private float _playerOfSet;
    private Vector2 _fireRate;
    private BaseWeapon _weapon;

    public int ID => _id;

    public Range RangeType => _rangeType;
    public void Init(int hp, float moveSpeed, Vector2 fireRate,BaseWeapon weapon, Range rangeType,int id)
    {
        _id = id;
        _hp = hp;
        _weapon = weapon;
        _moveSpeed = moveSpeed;
        _fireRate = fireRate;
        _rangeType = rangeType;

        StartCoroutine(Move());
        StartCoroutine(Shot());
    }

    public void SetRange(float range, float playerOfSet)
    {
        _rage = range;
        _playerOfSet = playerOfSet;
    }

    private IEnumerator Shot()
    {
        while (true)
        {
            _shotHandler.Shot();
            ShootProjectile();
            yield return new WaitForSeconds(Random.Range(_fireRate.x, _fireRate.y));
        }
    }

    private void ShootProjectile()
    {
        var _rotation = (Player.PlayerManager.Instance.transform.position - transform.position).normalized;
        Quaternion quaternion = Quaternion.Euler(_rotation.x, _rotation.y, 0);
        float _angle = Mathf.Atan2(-_rotation.x, _rotation.y) * Mathf.Rad2Deg;
        _weapon.Shoot(quaternion,_angle,transform);
    }

    private IEnumerator Move()
    {
        int time = 0;
        while (true)
        {
            if (Vector2.Distance(transform.position, Player.PlayerManager.Instance.transform.position) < _playerOfSet)
            {
                var dirctain = (Player.PlayerManager.Instance.transform.position - transform.position);
                time = 4;
                _dircsation = dirctain * 3;
            }
            else
            {
                Vector2 vector2 = Player.PlayerManager.Instance.transform.position;
                var x = Random.Range(vector2.x - _rage, vector2.x + _rage);
                var y = Random.Range(vector2.y - _rage, vector2.y + _rage);
                _dircsation = new Vector2(x, y);
                time = Random.Range(0, 5);
            }


            yield return new WaitForSeconds(time);
        }
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _dircsation, _moveSpeed * Time.deltaTime);
    }

    private void CheckHp()
    {
        if (_hp <= 0)
        {
            Dispose();
            OnEnemyDied?.Invoke(this);
        }
    }

    public void DoDamage(int damage)
    {
        _hp -= damage;
        CheckHp();
    }


   public void Dispose()
   { 
       gameObject.SetActive(false);
      OnDispos?.Invoke(this);
   }

   public event Action<Enemy> OnDispos;
}

public enum EnemyShotType
{
    Shotgun,
    Rifle,
    Circle
}

public enum Range
{
    Short,
    Long
}
