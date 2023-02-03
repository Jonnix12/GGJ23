using System;
using System.Collections;
using Pool;
using UnityEngine;
using Projectile;
using Random = UnityEngine.Random;


public class Enemy : MonoBehaviour , IDisposable , IPoolable<Enemy>

{
    public event Action<Enemy> OnEnemyDied;

    private int _hp;

    private float _moveSpeed;

    private Vector2 _dircsation;

    private Range _rangeType;
    private float _rage;
    private float _playerOfSet;
    private Vector2 _fireRate;
    private BaseProjectile _projectile;

    public Range RangeType => _rangeType;
    public void Init(int hp, float moveSpeed, BaseProjectile projectil, Vector2 fireRate, Range rangeType)
    {
        _hp = hp;
        _projectile = projectil;
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
            ShootProjectile();
            yield return new WaitForSeconds(Random.Range(_fireRate.x, _fireRate.y));
        }
    }

    private void ShootProjectile()
    {
        var _rotation = (Player.PlayerManager.Instance.transform.position - transform.position).normalized;
        Quaternion quaternion = Quaternion.Euler(_rotation.x, _rotation.y, 0);
        float _angle = Mathf.Atan2(-_rotation.x, _rotation.y) * Mathf.Rad2Deg;
        BaseProjectile projectile = ProjectilePool.Instance.Pull(_projectile, transform);
        projectile.transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
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
